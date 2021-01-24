    static class Program
    {
        static void Main(string[] args)
        {
            var ray = new Ray() {
                Point = new Vector2(-3, 1),
                Direction = new Vector2(2, 0.5f)
            };
            var circle = new Circle
            {
                Center = new Vector2(1, 1),
                Radius = 4
            };
            var points = Geometry.Intersect(circle, ray);
            if(points.Length>0)
            {
                foreach(var point in points)
                {
                    Console.WriteLine(point.ToString());
                }
            }
            else
            {
                Console.WriteLine("Circle and Ray do not intersect");
            }
        }
    }
