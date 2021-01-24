    using System;
    using System.Reflection;
    using System.Threading.Tasks;
    using System.Runtime.CompilerServices;
    
    public class StateMachineProvider
    {
        private static readonly StateMachineProvider instance = new StateMachineProvider();
        
        public static StateMachineProvider GetStateMachine() => instance;
        
        public StateMachineAwaiter GetAwaiter() => new StateMachineAwaiter();
        
        public class StateMachineAwaiter : INotifyCompletion
        {
            private Action continuation;
            
            public bool IsCompleted => continuation != null;
    
            public void OnCompleted(Action continuation)
            {
                this.continuation = continuation;
                // Fire the continuation in a separate task.
                // (We shouldn't just call it synchronously.)
                Task.Run(continuation);
            }
            
            public IAsyncStateMachine GetResult()
            {
                var target = continuation.Target;
                var field = target.GetType().GetField("m_stateMachine", BindingFlags.NonPublic | BindingFlags.Instance);
                return (IAsyncStateMachine) field.GetValue(target);
            }
        }
    }
    
    class Test
    {
        static void Main()
        {
            AsyncMethod().Wait();
        }
        
        static async Task AsyncMethod()
        {
            int x = 10;
            IAsyncStateMachine machine = await StateMachineProvider.GetStateMachine();
            Console.WriteLine(x);
            Console.WriteLine($"State machine type: {machine.GetType()})");
            Console.WriteLine("Fields:");
            foreach (var field in machine.GetType()
                     .GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance))
            {
                Console.WriteLine($"{field.Name}: {field.GetValue(machine)}");
            }
        }
    }
