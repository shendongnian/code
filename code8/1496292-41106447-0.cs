    public class Circle
        {
            // In C# this is called a "property" - you can get or set its values
            public double x { get; set; }
            public double y { get; set; }
            public double r { get; set; }
        }
        private static List<Circle> InitializeList()
        {
            Random random = new Random();
            List<Circle> listOfCircles = new List<Circle>();
            for (int i = 0; i < 30; i++)
            {
                // This is a special syntax that allows you to create an object
                // and initialize it at the same time
                // You could also create a custom constructor in Circle to achieve this
                Circle newCircle = new Circle()
                {
                    x = random.NextDouble(),
                    y = random.NextDouble(),
                    r = random.NextDouble()
                };
                listOfCircles.Add(newCircle);
            }
            return listOfCircles;
        }
