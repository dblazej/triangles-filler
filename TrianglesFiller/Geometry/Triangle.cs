namespace TrianglesFiller
{
    class Triangle
    {
        public Point3D? PointA { get; set; }
        public Point3D? PointB { get; set; }
        public Point3D? PointC { get; set; }
        public Point3D? CenterPoint { get; set; }
        public double Area { get; set; }
        public Dictionary<Point, Point3D>? Pixels { get; set; }
        public Dictionary<Point, Point3D>? NormalVectors { get; set; }

        public void Draw(PaintEventArgs e)
        {
            if (PointA == null || PointB == null || PointC == null) return;
            Pen pen = new(Color.Violet);
            e.Graphics.DrawLine(pen, new Point((int)PointA.X, (int)PointA.Y), new Point((int)PointB.X, (int)PointB.Y));
            e.Graphics.DrawLine(pen, new Point((int)PointA.X, (int)PointA.Y), new Point((int)PointC.X, (int)PointC.Y));
            e.Graphics.DrawLine(pen, new Point((int)PointB.X, (int)PointB.Y), new Point((int)PointC.X, (int)PointC.Y));
            e.Graphics.FillEllipse(Brushes.Violet, new Rectangle((int)(this.PointA.X - 3), (int)(this.PointA.Y - 3), 6, 6));
            e.Graphics.FillEllipse(Brushes.Violet, new Rectangle((int)(this.PointB.X - 3), (int)(this.PointB.Y - 3), 6, 6));
            e.Graphics.FillEllipse(Brushes.Violet, new Rectangle((int)(this.PointC.X - 3), (int)(this.PointC.Y - 3), 6, 6));
        }
        public void FillTriangle(FastBitmap bm, Point light, bool vertices)
        {
            if (PointA == null || PointB == null || PointC == null) return;
            if (vertices)
            {
                Color paColor = this.GetFillColorForPixel(light, this.PointA.X, this.PointA.Y, this.PointA.Z);
                Color pbColor = this.GetFillColorForPixel(light, this.PointB.X, this.PointB.Y, this.PointB.Z);
                Color pcColor = this.GetFillColorForPixel(light, this.PointC.X, this.PointC.Y, this.PointC.Z);
                if (this.Pixels == null) return;
                foreach (Point pixel in this.Pixels.Keys) bm.SetPixel(pixel.X, pixel.Y, this.InterpolateColorForPixel(pixel.X, pixel.Y, paColor, pbColor, pcColor));
            }
            else
            {
                if(this.Pixels == null || this.CenterPoint == null) return;
                foreach (Point pixel in this.Pixels.Keys) bm.SetPixel(pixel.X, pixel.Y, this.GetFillColorForPixel(light, pixel.X, pixel.Y,
                    (this.Pixels.ContainsKey(new(pixel.X, pixel.Y)) ? this.Pixels[new(pixel.X, pixel.Y)].Z : this.CenterPoint.Z)));
            }
        }
        private Color InterpolateColorForPixel(int x, int y, Color p1Color, Color p2Color, Color p3Color)
        {
            Point currPoint = new(x, y);
            if (this.Area == 0 || PointA == null || PointB == null || PointC == null) return p1Color;

            Point pa = new((int)PointA.X, (int)PointA.Y);
            Point pb = new((int)PointB.X, (int)PointB.Y);
            Point pc = new((int)PointC.X, (int)PointC.Y);
            double p1Alfa = Math.Abs(((currPoint.X - pb.X) * (currPoint.Y - pc.Y) - (currPoint.Y - pb.Y) * (currPoint.X - pc.X)) / 2.0) / this.Area;
            double p2Alfa = Math.Abs(((currPoint.X - pa.X) * (currPoint.Y - pc.Y) - (currPoint.Y - pa.Y) * (currPoint.X - pc.X)) / 2.0) / this.Area;
            double p3Alfa = Math.Abs(((currPoint.X - pa.X) * (currPoint.Y - pb.Y) - (currPoint.Y - pa.Y) * (currPoint.X - pb.X)) / 2.0) / this.Area;

            return Color.FromArgb(255, Math.Min(255, (int)(p1Color.R * p1Alfa + p2Color.R * p2Alfa + p3Color.R * p3Alfa)),
                Math.Min(255, (int)(p1Color.G * p1Alfa + p2Color.G * p2Alfa + p3Color.G * p3Alfa)), Math.Min(255, (int)(p1Color.B * p1Alfa + p2Color.B * p2Alfa + p3Color.B * p3Alfa)));
        }
        private Color GetFillColorForPixel(Point light, double x, double y, double z)
        {
            double[] lightColor = new double[] { MainWindow.LightColor.R / (double)255, MainWindow.LightColor.G / (double)255, MainWindow.LightColor.B / (double)255 };
            double[] objectColor = new double[] { MainWindow.SurfaceSolidColor.R / 255.0, MainWindow.SurfaceSolidColor.G / 255.0, MainWindow.SurfaceSolidColor.B / 255.0 };
            int[] returnColor = new int[] { 0, 0, 0 };

            Point3D L = new() { X = (light.X - x), Y = (light.Y - y), Z = (MainWindow.LightZ - z) };
            double length = Math.Sqrt(L.X * L.X + L.Y * L.Y + L.Z * L.Z);
            L.X /= length;
            L.Y /= length;
            L.Z /= length;

            Point tmp = new((int)x, (int)y);
            Point3D N;
            if (this.NormalVectors == null) N = Surface.GetNormalVersor(tmp.X, tmp.Y);
            else N = (this.NormalVectors.ContainsKey(tmp)) ? this.NormalVectors[tmp] : Surface.GetNormalVersor(tmp.X, tmp.Y);

            double nCosL = N.X * L.X + N.Y * L.Y + N.Z * L.Z;
            double vCosR = Math.Max(N.Z * 2 * nCosL - L.Z, 0.0);
            double fL = MainWindow.Kd * Math.Max(nCosL, 0.0);
            double sL = vCosR > 0 ? MainWindow.Ks * Math.Pow(vCosR, MainWindow.M) : 0.0;
            for (int i = 0; i < 3; i++)
            {
                double iL = lightColor[i];
                double iO = objectColor[i];
                double iLiO = iL * iO;
                returnColor[i] = (int)((fL * iLiO + sL * iLiO) * 255);
                returnColor[i] = Math.Min(255, returnColor[i]);
                returnColor[i] = Math.Max(0, returnColor[i]);
            }

            return Color.FromArgb(255, returnColor[0], returnColor[1], returnColor[2]);
        }
    }
}