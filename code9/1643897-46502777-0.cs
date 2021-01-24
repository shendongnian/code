     [DependsOn(typeof(MySampleProjectApplicationModule))]
        public class MyWindowsServiceManagementModule : AbpModule
        {
            public override void Initialize()
            {
                IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
                
            }
     
        }
	
