      public static List<double> Xs(this List<Point3D> pts) {
            List<double> xs = new List<double>(pts.Count);
            foreach (Point3D pt in pts) {
                xs.Add(pt.X);
            }
            return xs;
        }
        public static List<double> Ys(this List<Point3D> pts) {
            List<double> ys = new List<double>(pts.Count);
            foreach (Point3D pt in pts) {
                ys.Add(pt.Y);
            }
            return ys;
        }
        public static List<double> Zs(this List<Point3D> pts) {
            List<double> zs = new List<double>(pts.Count);
            foreach (Point3D pt in pts) {
                zs.Add(pt.Z);
            }
            return zs;
        }
