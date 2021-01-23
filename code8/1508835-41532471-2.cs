    public class Matrix3x3 : Matrix
    {
        public Matrix3x3(double m11, double m12, double m13,
                         double m21, double m22, double m23,
                         double m31, double m32, double m33)
        {
            Rows = 3;
            Cols = 3;
            Mat = new double[Rows * Cols];
            Mat[0] = m11;
            Mat[1] = m12;
            Mat[2] = m13;
            Mat[3] = m21;
            Mat[4] = m22;
            Mat[5] = m23;
            Mat[6] = m31;
            Mat[7] = m32;
            Mat[8] = m33;
        }
        public static Matrix3x3 CreateTranslationMatrix(double x, double y)
        {
            return new Matrix3x3(1, 0, x,
                                 0, 1, y,
                                 0, 0, 1);
        }
        public static Matrix3x3 CreateScaleMatrix(double x, double y)
        {
            return new Matrix3x3(x, 0, 0,
                                 0, y, 0,
                                 0, 0, 1);
        }
        public static Matrix3x3 CreateIdentityMatrix()
        {
            return new Matrix3x3(1, 0, 0,
                                 0, 1, 0,
                                 0, 0, 1);
        }
        public static Matrix3x3 CreateRotationMatrix(double radians)
        {
            var cos = Math.Cos(radians);
            var sin = Math.Sin(radians);
            return new Matrix3x3(cos, -sin, 0,
                                 sin, cos, 0,
                                 0, 0, 1);
        }
