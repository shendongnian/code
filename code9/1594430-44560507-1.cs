    namespace MRP
    {
    public enum ModeGeneration
            {
                ByRequest,
                ByCommit
            }
        public class Generator
        {
            
        }
    }
    
    // CustomerOrderWrapper.cs
    namespace MRP
    {
        class CustomerOrderWrapper
        {
            readonly ModeGeneration _mode;
        }
    }
