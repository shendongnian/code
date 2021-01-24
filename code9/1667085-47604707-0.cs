               var container = Bootstrapper.WireUp();//return windsoerContainer
            container.Register(Classes.FromAssemblyContaining<FrmLogin>()
                .BasedOn<RadForm>().LifestyleSingleton());
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(container.Resolve<FrmLogin>());
