        public class MyWindowsServiceManagementBootstrapper : AbpBootstrapper
            {
               
                public override void Initialize()
                {
                    base.Initialize(); 
                }
        
                public override void Dispose()
                {
                    //release your resources...
                    base.Dispose();
                }
            }
