    [assembly: WebActivatorEx.PreApplicationStartMethod(typeof(MyModule.App_Start.MyModuleStartup), "Start")]
    namespace MyModule.App_Start
    {
        public static class MyModuleStartup
        {
          public static void Start()
          {
             MyBusinessClass.RegisterMyCustomRole("MyNewRole");
          }
        }
    }
