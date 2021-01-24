    using System;
    
    namespace Test
    {
        public class car
        {
            public string brand { get; set; }
            public tire _id { get; set; }
    
            public string GetAttributes()
            {
                var type = this.GetType();
                var returnValue = "";
                var properties = type.GetProperties();
                foreach (var propertyInfo in properties)
                {
                    // Look at properties of the car
                    if (propertyInfo.Name.Contains("_") && propertyInfo.PropertyType.IsValueType &&
                        !propertyInfo.PropertyType.IsPrimitive)
                    {
                        var propValue = propertyInfo.GetValue(this);
    
                        var propType = propValue.GetType();
                        var propProperties = propType.GetProperties();
    
                        foreach (var propPropertyInfo in propProperties)
                        {
                            // Now get the properties of tire
                            // Here I just concatenate to a string - you can tweak this
                            returnValue += propPropertyInfo.GetValue(propValue).ToString();
                        }
                    }
                }
                return returnValue;
            }
        }
    
        public struct tire
        {
            public int id { get; set; }
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                var mynewtire = new tire()
                {
                    id = 5
                };
    
                var mynewcar = new car()
                {
                    _id = mynewtire
                };
                Console.WriteLine(mynewcar.GetAttributes());
    
                Console.ReadLine();
            }
        }
    }
