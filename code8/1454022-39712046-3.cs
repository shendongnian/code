    namespace MyWcfProgram.Logic
    {
        public class Logic : ILogic
        {
            private readonly IData dataAccess;
    
            public Logic(IData dataAccess)
            {
                if (dataAccess == null)
                {
                    throw new Exception();
                }
    
                this.dataAccess = dataAccess;
            }
