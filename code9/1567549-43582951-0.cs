    using System;
    
    public class Test
    {
        private int[] array = new int[10];
    
        static void Main()
        {
            Test instance = null;
            
            // This would throw a NullReferenceException
            // because instance is null at the start of the statement.
            // ExecuteSideEffect never gets called.        
            // instance.array[100] = ExecuteSideEffect(() => instance = new Test());
            
            instance = new Test();
            
            // This would throw an IndexOutOfBoundsException
            // because instance.array is evaluated before ExecuteSideEffect.
            // The exception is only thrown when the assignment is performed.
            // instance.array[100] = ExecuteSideEffect(() => instance.array = new int[1000]);
            
            int index = 5;
            // This modifies array index 5 because index is evaluated
            // before EvaluateSideEffect
            instance.array[index] = ExecuteSideEffect(() => index = 1);
            Console.WriteLine(instance.array[5]); // 10
        }
        
        private static int ExecuteSideEffect(Action action)
        {
            action();
            return 10;
        }
    }
