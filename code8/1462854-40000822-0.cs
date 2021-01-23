        static void Main(string[] args)
        {
            string obj1 = "a string";
            int obj2 = 12;
            DateTime obj3 = DateTime.Today;
            object[] obj_array = { obj1, obj2, obj3 };
            foreach (object obj in obj_array)
            {
                //Print value
                Console.WriteLine("Value: " + obj.ToString());
                //Print property names
                Console.WriteLine("Property Names:");
                foreach (PropertyInfo prop in obj.GetType().GetProperties())
                {
                    Console.WriteLine(prop.Name);
                }
                Console.WriteLine();
            }
            Console.Read();
        }
