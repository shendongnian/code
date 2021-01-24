     class Program
        {
            static void Main(string[] args)
            {
                Tuple<string, string> tuples = new Tuple<string, string>("test","test");
                foreach (string item in TupleToEnumerable<string>(tuples))
                {
                    Console.WriteLine(item);   
    
                }
            }
    
            private static IEnumerable<T> TupleToEnumerable<T>(object tuple)
            {
                Type t = tuple.GetType();
                if (t.IsGenericType && t.GetGenericTypeDefinition() == typeof(Tuple<,>))
                {
                    var x = tuple as Tuple<T, T>;
                    yield return x.Item1;
                    yield return x.Item2;
                }
            }
        }
 
