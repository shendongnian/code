    class Program
        {
            static void Main(string[] args)
            {
    
                PointF point1 = new PointF(10, 20);
                System.Console.WriteLine(point1);
                Console.Read();
    
            }
    
    
        }
        public class PointF
        {
            public float X { get; set; }
            public float Y { get; set; }
    
            public PointF(float x, float y)
            {
                this.X = x;
                this.Y = y;
            }
            public override string ToString()
            {
                return "{ " + X.ToString(CultureInfo.InvariantCulture) + " ," + Y.ToString(CultureInfo.InvariantCulture) + " }";
              
            }
        }
