    namespace CallInternalExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var classInstance = new SealedInternalExample();
                var methods = classInstance.GetType().GetMethods(
                    System.Reflection.BindingFlags.NonPublic | 
                    System.Reflection.BindingFlags.Public | 
                    System.Reflection.BindingFlags.Instance);
    
                for (int x = 0; x < methods.Length; x++)
                    System.Console.WriteLine("{0}: {1}", x, methods[x].Name);
    
                var internalMethod = methods.FirstOrDefault
                    ((m) => m.Name.Equals("TryAndExecuteMe", 
                    StringComparison.InvariantCulture));
    
                internalMethod.Invoke(classInstance, new object[] { 15 });
    
            }
        }
    }
