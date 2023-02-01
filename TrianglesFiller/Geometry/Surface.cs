namespace TrianglesFiller
{
    class Surface
    {
        private List<Triangle>? trianglesMesh;
        public Point3D Center { get; private set; }
        public int Radius { get; private set; }
        public Surface(Point3D center, int radius)
        {
            this.Center = center;
            this.Radius = radius;
        }
        public void Draw(PaintEventArgs e, FastBitmap bm, Point light, bool trianglesVisible, bool vertices)
        {
            if (this.trianglesMesh == null) return;
            if(trianglesVisible) this.trianglesMesh.ForEach(triangle => triangle.Draw(e));
            else Parallel.For(0, this.trianglesMesh.Count - 1, num => this.trianglesMesh[num].FillTriangle(bm, light, vertices));
        }

        public void Triangulation()
        {
            this.trianglesMesh = new List<Triangle>();
            Point3D[,] pointList = new Point3D[26, 51];
            for (int i = 0; i <= 25; i++)
            {
                for (int j = -25; j <= 25; j++)
                {
                    pointList[i, j + 25] = new Point3D
                    {
                        X = (Math.Sin(i * (Math.PI / 25)) * Math.Cos(j * (Math.PI / 25))) * this.Radius + this.Center.X,
                        Y = (Math.Sin(i * (Math.PI / 25)) * Math.Sin(j * (Math.PI / 25))) * this.Radius + this.Center.Y,
                        Z = (Math.Cos(i * (Math.PI / 25))) * this.Radius + this.Center.Z
                    };
                }
            }

            for (int i = 1; i <= pointList.GetLength(0) - 1; i++)
            {
                for (int j = 0; j <= pointList.GetLength(1) - 1; j++)
                {
                    Triangle t1 = new()
                    {
                        PointA = pointList[i, j],
                        PointB = pointList[i, (j + 1) % pointList.GetLength(1)],
                        PointC = pointList[i - 1, j]
                    };

                    if (t1.PointA.Z >= 0)
                    {
                        t1.CenterPoint = new Point3D()
                        {
                            X = (t1.PointA.X + t1.PointB.X + t1.PointC.X) / 3.0,
                            Y = (t1.PointA.Y + t1.PointB.Y + t1.PointC.Y) / 3.0,
                            Z = (t1.PointA.Z + t1.PointB.Z + t1.PointC.Z) / 3.0
                        };
                        t1.Area = Math.Abs((((int)t1.PointA.X - (int)t1.PointB.X) * ((int)t1.PointA.Y - (int)t1.PointC.Y) - ((int)t1.PointA.Y -
                            (int)t1.PointB.Y) * ((int)t1.PointA.X - (int)t1.PointC.X)) / 2.0);

                        var points = new List<Point> { new((int)t1.PointA.X, (int)t1.PointA.Y), new((int)t1.PointB.X, (int)t1.PointB.Y), new((int)t1.PointC.X, (int)t1.PointC.Y) };
                        t1.Pixels = new Dictionary<Point, Point3D>();
                        ScanLine.FillPolygon(points, (x, y) => t1.Pixels[new Point(x, y)] = new Point3D()
                        {
                            X = x,
                            Y = y,
                            Z = Math.Max(0.0, Math.Sqrt(MainWindow.surfaceRadius * MainWindow.surfaceRadius - Math.Pow(x - MainWindow.center.X, 2) - Math.Pow(y - MainWindow.center.Y, 2)))
                        });

                        t1.NormalVectors = new Dictionary<Point, Point3D>();
                        foreach (Point pixel in t1.Pixels.Keys) t1.NormalVectors[pixel] = Surface.GetNormalVersor((int)pixel.X, (int)pixel.Y);

                        trianglesMesh.Add(t1);
                    }

                    Triangle t2 = new()
                    {
                        PointA = pointList[i, (j + 1) % pointList.GetLength(1)],
                        PointB = pointList[i - 1, (j + 1) % pointList.GetLength(1)],
                        PointC = pointList[i - 1, j]
                    };

                    if (t2.PointA.Z >= 0)
                    {
                        t2.CenterPoint = new Point3D()
                        {
                            X = (t2.PointA.X + t2.PointB.X + t2.PointC.X) / 3.0,
                            Y = (t2.PointA.Y + t2.PointB.Y + t2.PointC.Y) / 3.0,
                            Z = (t2.PointA.Z + t2.PointB.Z + t2.PointC.Z) / 3.0
                        };
                        t2.Area = Math.Abs((((int)t2.PointA.X - (int)t2.PointB.X) * ((int)t2.PointA.Y - (int)t2.PointC.Y) - ((int)t2.PointA.Y - 
                            (int)t2.PointB.Y) * ((int)t2.PointA.X - (int)t2.PointC.X)) / 2.0);

                        var points = new List<Point> { new((int)t2.PointA.X, (int)t2.PointA.Y), new((int)t2.PointB.X, (int)t2.PointB.Y), new((int)t2.PointC.X, (int)t2.PointC.Y) };
                        t2.Pixels = new Dictionary<Point, Point3D>();
                        ScanLine.FillPolygon(points, (x, y) => t2.Pixels[new Point(x, y)] = new Point3D()
                        {
                            X = x,
                            Y = y,
                            Z = Math.Max(0.0, Math.Sqrt(MainWindow.surfaceRadius * MainWindow.surfaceRadius - Math.Pow(x - MainWindow.center.X, 2) - Math.Pow(y - MainWindow.center.Y, 2)))
                        });

                        t2.NormalVectors = new Dictionary<Point, Point3D>();
                        foreach (Point pixel in t2.Pixels.Keys) t2.NormalVectors[pixel] = Surface.GetNormalVersor((int)pixel.X, (int)pixel.Y);

                        trianglesMesh.Add(t2);
                    }
                }
            }
        }
        public static Point3D GetNormalVersor(int x, int y)
        {
            int x1 = x - (int)MainWindow.center.X;
            int y1 = y - (int)MainWindow.center.Y;
            Point3D n = new() { X = x1, Y = y1, Z = Math.Sqrt(MainWindow.surfaceRadius * MainWindow.surfaceRadius + x1 * x1 + y1 * y1) };
            double length = Math.Sqrt(n.X * n.X + n.Y * n.Y + n.Z * n.Z);
            n.X /= length;
            n.Y /= length;
            n.Z /= length;
            return n;
        }
    }
}