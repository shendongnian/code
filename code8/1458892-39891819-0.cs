        static void miniTest() {
            // first triangle 
            Vector3D v1 = new Vector3D();
            Vector3D v2 = new Vector3D(2, 0, 0);
            Vector3D v3 = new Vector3D(2, 3, 0);
            Vector3D w1 = new Vector3D(0,-1, 0);
            Vector3D w2 = new Vector3D(0 , -3, 0);
            Vector3D w3 = new Vector3D(3, -1, 0);
            double[,] transofrmation = getTrMatrix(v1, v2, v3, w1, w2, w3);    
        }
        public static double[,] getTrMatrix(Vector3D V1, Vector3D V2, Vector3D V3, Vector3D W1, Vector3D W2, Vector3D W3) {
            Vector3D s1 = V2 - V1;
            s1.Normalize();
            Vector3D z1 = W2 - W1;
            z1.Normalize();
            double angle = Math.Acos(Vector3D.DotProduct(s1, z1));
            double[,] rotT = new double[,] {
                { Math.Cos(angle), -Math.Sin(angle), 0},
                { Math.Sin(angle), Math.Cos(angle), 0},
                { 0,0,1},
            };
            double[] rotatedV1 = multiply(rotT, V1);
            Vector3D translation = new Vector3D( W1.X - rotatedV1[0], W1.Y - rotatedV1[1], W1.Z - rotatedV1[2]);
            double[,] T = new double[,] {
                { Math.Cos(angle), -Math.Sin(angle), 0, translation.X},
                { Math.Sin(angle), Math.Cos(angle), 0, translation.Y},
                { 0,0,1, translation.Z},
                {0,0,0,1 } };
            return T;
        }
        // apply rotation matrix to vector
        static double[] multiply(double[,] rotMat, Vector3D vec) {
            double[] result = new double[3];
            result[0] = rotMat[0, 0] * vec.X + rotMat[0, 1] * vec.Y + rotMat[0, 2] * vec.Z;
            result[1] = rotMat[1, 0] * vec.X + rotMat[1, 1] * vec.Y + rotMat[1, 2] * vec.Z;
            result[1] = rotMat[2, 0] * vec.X + rotMat[2, 1] * vec.Y + rotMat[2, 2] * vec.Z;
            return result;
        }
