        static void Main(string[] args)
        {
            //Create a string array containing the desired property names, in this case I'll use a loop
            List<string> DesiredProperties = new List<string>(); 
            
            for (int i = 0; i < 100; i++)
            {
                DesiredProperties.Add(string.Format("Property{0}", i));
            }
            //Call the method that returns the object and pass the array as parameter
            var Bus = CreateDynamicObject(DesiredProperties);
            //Display one of the properties
            Console.WriteLine(Bus.Property99);
            Console.Read();
        }
        private static dynamic CreateDynamicObject(List<string> PropertyList)
        {
            dynamic obj = new System.Dynamic.ExpandoObject();
            foreach (string Prop in PropertyList)
            {
                //You can add the properties using a dictionary. You can also give them an initial value
                var dict = (IDictionary<string, object>)obj;
                dict.Add(Prop, string.Format("The value of {0}", Prop));
            }
            return obj;
        }
