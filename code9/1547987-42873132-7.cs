    public static class TransformEx
    {
        // method to convert degree into radians
        public static double ToRadians(this double degree)
        {
            return ( ( degree % 360.0D ) / 180.0D ) * Math.PI;
        }
    
        // get the rotation matrix
        public static Matrix GetRotationMatrix(this double angle, Vector2 rotationCenter)
        {
            double radians = angle.ToRadians();
            double cos = Math.Cos(radians);
            double sin = Math.Sin(radians);
     
            return new Matrix
            {
                M11 = cos,
                M12 = sin,
                M21 = -sin,
                M22 = cos,
			    M41 = ( rotationCenter.X * ( 1.0 - cos ) ) + ( rotationCenter.Y * sin ),
			    M42 = ( rotationCenter.Y * ( 1.0 - cos ) ) - ( rotationCenter.X * sin )
            };
        }
        // get translation matrix
        public static Matrix GetTranslationMatrix(this Vector2 position)
        {
            return new Matrix
            {
                M41 = position.X,
                M42 = position.Y,
                M43 = 0
            };
        }
    }
