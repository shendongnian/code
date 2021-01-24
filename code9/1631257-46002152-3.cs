    public class SomeClass
        {
            public void MethodA()
            {
                Console.WriteLine("MethodA");
            }
        }
        static void Main(string[] args)
        {
            Type type = typeof(SomeClass);
            // Obviously, you'll want to replace the hardcode with your string
            MethodInfo method = type.GetMethod("MethodA");
            SomeClass cls = new SomeClass();
            // The second argument is the parameters; I pass null here because
            // there aren't any in this case
            method.Invoke(cls, null);
        }
