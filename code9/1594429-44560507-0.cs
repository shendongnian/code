    namespace MRP
    {
        public class Generator
        {
            public enum ModeGeneration
            {
                ByRequest,
                ByCommit
            }
        }
    }
    
    // CustomerOrderWrapper.cs
    namespace MRP
    {
        class CustomerOrderWrapper
        {
            readonly Generator.ModeGeneration _mode;
        }
    }
