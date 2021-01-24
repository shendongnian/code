    public class Program
    {
        public static string ConvertToString(object value)
        {
            return value == null ? null : value.ToString();
        }
    
        // We cache the adders they are expensive to create but fast to execute, create once use many times 
        public static Lazy<List<Action<Person, List<string>>>> PropertyAdders = new Lazy<List<Action<Person, List<string>>>>(() => CreateAdders<Person>());
    
        public static List<Action<T, List<string>>> CreateAdders<T>()
        {
            // The convert to string method we use for converting the property value to a string
            var converterMethod = typeof(Program).GetMethod("ConvertToString");
            // The add method of the list
            var addMethod = typeof(List<string>).GetMethod("Add");
            // Array of actions one for each property in the object
            var result = new List<Action<T, List<string>>>();
            foreach (var prop in typeof(T).GetProperties())
            {
                //We want to create a lambda that essentially looks like this:
                // (o, list) => list.Add(ConvertToString((object)o.Prop));
                // We create the two lambda parameters
                var item = Expression.Parameter(typeof(T));
                var list = Expression.Parameter(typeof(List<string>));
    
                // We create the actual lambda expression 
                var adderExp = Expression.Lambda<Action<T, List<string>>>(
                    Expression.Call(list, addMethod, // Call to list.Add
                        Expression.Call(converterMethod, // Call to Program.ConvertToString
                            Expression.Convert( //Conversion of property value to object
                                Expression.MakeMemberAccess(item, prop), // member acecss o.Prop
                            typeof(object))
                        )
                    ), item, list
                );
    
                result.Add(adderExp.Compile());
            }
            return result;
        }
        private static List<string> ConvertObjectToStringList(Person person)
        {
            List<string> str = new List<string>();
            foreach (var adder in PropertyAdders.Value)
            {
                adder(person, str);
            }
            return str;
        }
    
        public static void Main()
        {
            ConvertObjectToStringList(new Person { Admin = 1, Id = 1, Name = "adas" });
        }
    }
