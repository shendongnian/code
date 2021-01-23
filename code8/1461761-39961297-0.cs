    public class Point3D {
        public double X {get; set;}
        public double Y {get; set;}
        public double Z {get; set;}
    }
    List<Point3D> list = new List<Point3D>();
    for (int i = 0; i < PointX.Count; i++) {
        list.Add(new Point3D { X = PointX[i], Y = PointY[i], Z = PointZ[i] });
    }
