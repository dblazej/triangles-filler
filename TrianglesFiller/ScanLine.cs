namespace TrianglesFiller
{
    public static class ScanLine
    {
        public class AET
        {
            public Point A { get; private set; }
            public Point B { get; private set; }
            public double X { get; private set; }
            public AET(Point a, Point b, int y)
            {
                this.A = a;
                this.B = b;
                this.SetX(y);
            }
            public void SetX(int y)
            {
                double tmp = ((double)(A.Y - B.Y) / (double)(A.X - B.X));
                X = Math.Abs(A.X - B.X) < 1 ? A.X : (y - (A.Y - tmp * A.X)) / tmp;
            }
        }
        public static void FillPolygon(List<Point> points, Action<int, int> action)
        {
            List<int> ind = SortVertices(points, out int yMin, out int yMax);
            List<AET> aet = new();

            for (int y = yMin; y <= yMax; y++)
            {
                for (int i = 0; i < ind.Count; i++)
                {
                    int curr = ind[i];
                    if (points[curr].Y == y - 1)
                    {
                        int prev = (ind[i] - 1);
                        if (prev < 0) prev = ind.Count - 1;
                        if (points[prev].Y < points[curr].Y) aet.RemoveAll(node => (node.A == points[prev] && node.B == points[curr]) || (node.A == points[curr] && node.B == points[prev]));
                        else if (points[prev].Y > points[curr].Y) aet.Add(new AET(points[prev], points[curr], y));

                        int next = (ind[i] + 1) % ind.Count;
                        if (points[next].Y < points[curr].Y) aet.RemoveAll(node => (node.A == points[next] && node.B == points[curr]) || (node.A == points[curr] && node.B == points[next]));
                        else if (points[next].Y > points[curr].Y) aet.Add(new AET(points[next], points[curr], y));
                    }
                }

                aet.Sort((AET a, AET b) => a.X.CompareTo(b.X));

                for (int i = 0; i < aet.Count - 1; i += 2)
                {
                    int xMin = (int)aet[i].X;
                    int xMax = (int)aet[i + 1].X;
                    for (int x = xMin; x < xMax; x++) action(x, y);
                }
                aet.ForEach(node => node.SetX(y));
            }
        }
        private static List<int> SortVertices(List<Point> points, out int yMin, out int yMax)
        {
            List<int> sortedIndexes = new();
            for (int i = 0; i < points.Count; i++) sortedIndexes.Add(i);

            sortedIndexes.Sort((int a, int b) => points[a].Y.CompareTo(points[b].Y));
            yMin = points[sortedIndexes[0]].Y;
            yMax = points[sortedIndexes.Last()].Y;

            return sortedIndexes;
        }
    }
}