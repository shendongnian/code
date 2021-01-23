    private static void DisplayGenericTypes<T, Q, R, S>()
        {
            // The output of DisplayGenericTypes<int, string, double, float>(); is int, string, double, float
            foreach (Type t in new[] { typeof(T), typeof(Q), typeof(R), typeof(S)})
            {
                Console.WriteLine(t.Name);
            }
            Type[] generics = MethodInfo.GetCurrentMethod().GetGenericArguments();
            // Output is T, Q, R, S
            foreach (Type t in generics)
            {
                Console.WriteLine(t.Name);
            }
        }
