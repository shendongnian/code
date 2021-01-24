    static void Main(string[] args)
        {
            var types = new[] { typeof(ExampleClass), typeof(ExampleClass[]) };
            var objects = new List<object>();
            foreach (var type in types)
            {
                var typeInstance = type.GetElementType();
                if (typeInstance != null)
                {
                    Debug.WriteLine($"{typeInstance}");
                    objects.Add(Activator.CreateInstance(typeInstance));
                }
                else
                {
                    objects.Add(Activator.CreateInstance(type));
                }
            }
        }
       public class ExampleClass
       {
            public int X;
            public int Y;
       }
