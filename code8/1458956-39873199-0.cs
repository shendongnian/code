    namespace SOE2
    {
        class Program
        {
            static void Main(string[] args)
            {
                // vvv--- changing "dynamic" to "var" or "string" here fixes the issue
                dynamic parsedDocument = "";
    
                var mystery = new FailingClass<string>();
    
                Console.WriteLine("Entering...");
                mystery.FailingMethod(parsedDocument);
                Console.WriteLine("... and we are back!");
                Console.ReadLine();
            }
        }
    
        public abstract class CommonBase<T>
        {
        }
    
        // Technically, this class does nothing and deriving from it should be identical to deriving from CommonBase
        public abstract class FailingClassBase<T> : CommonBase<T>
        {
        }
    
        // However, deriving from CommonBase instead of FailingClassBase here also fixes the issue
        // ----------------------------vvvvvvvvvvvvvvvv
        public class FailingClass<T> : FailingClassBase<FailingClass<T>>
        {
            public void FailingMethod(T src)
            {
            }
        }
    }
