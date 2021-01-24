    public class Circle
    {
        public Vector2 Center { get; set; }
        public float Radius { get; set; }
    }
    public class Ray
    {
        public Vector2 Point { get; set; }
        public Vector2 Direction { get; set; }
        public Vector2 Along(float t)
        {
            return Point + t*Direction;
        }
    }
    public static class Geometry
    {
        public static Vector2[] Intersect(Circle circle, Ray ray)
        {
            float a = (ray.Point.LengthSquared()-circle.Radius*circle.Radius)/ray.Direction.LengthSquared();
            float b = Vector2.Dot(ray.Point, ray.Direction)/ray.Direction.LengthSquared();
            if(b*b-a>0)
            {
                // two intersection points
                float t1 = -b-(float)Math.Sqrt(b*b-a);
                float t2 = -b+(float)Math.Sqrt(b*b-a);
                return new Vector2[] {
                    ray.Along(t1),
                    ray.Along(t2),
                };
            }
            else if(b*b-a==0)
            {
                // one interection point
                float t = -b;
                return new Vector2[] { ray.Along(t) };
            }
            else
            {
                // no intersection, return empty array
                return new Vector2[0];
            }
        }
    }
