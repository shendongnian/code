    public static class Vector2Extensions
    {
        static Vector2 Rotate(this Vector2 v, double degrees)
        {
            return new Vector2(
                v.X * Math.Cos(degrees) - v.Y * Math.Sin(degrees),
                v.X * Math.Sin(degrees) + v.Y * Math.Cos(degrees)
            );
        }
    }
