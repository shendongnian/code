    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<FormInterceptor>();
            Castle.DynamicProxy.Generators.AttributesToAvoidReplicating.Add<System.Security.Permissions.UIPermissionAttribute>();
            // Register your forms
            builder.RegisterType<frmMain>()
                .Named<Form>("frmMain")
                .EnableClassInterceptors()
                .InterceptedBy(typeof(FormInterceptor));
            builder.RegisterType<frmSubForm>()
                .Named<Form>("frmSubForm")
                .EnableClassInterceptors()
                .InterceptedBy(typeof(FormInterceptor));
            FormFactory = new FormFactory(builder.Build());
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(FormFactory.CreateForm("frmMain").Value);
        }
        
        public static IFormFactory FormFactory { get; set; }
    }
