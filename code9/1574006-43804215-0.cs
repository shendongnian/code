    namespace ClassLibrary1
    {
        public sealed class SealedInternalExample
        {
    
            internal void TryAndExecuteMe (int someNumber)
            {
                System.Console.WriteLine("Internal method executed.  Parameter: {0}", 
                    someNumber);
            }
        }
    }
