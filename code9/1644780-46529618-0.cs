    namespace Stackoverflow46529447
    {
        class Program
        {
            static void Main(string[] args)
            {
                var numbers = new[] {8001, 8002, 8003};
                var executables = numbers.Select(x => Activator.CreateInstance(Type.GetType($"Stackoverflow46529447.Test{x:0000}")))
                    .OfType<IExecutable>()
                    .ToArray();
                foreach (var executable in executables)
                {
                    executable.Execute();
                }
            }
        }
        public class Test8001 : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Hello from Test 8001");
            }
        }
        public class Test8002 : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Hello from Test 8002");
            }
        }
        public class Test8003 : IExecutable
        {
            public void Execute()
            {
                Console.WriteLine("Hello from Test 8003");
            }
        }
        public interface IExecutable
        {
            void Execute();
        }
    }
