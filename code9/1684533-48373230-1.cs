    public class ConsoleCustomModule : NinjectModule {
        public override void Load() {
            Bind<IConnectionUtil>().To<ConnectionUtil>().InCallAndConnectionStringScope(GetConnectionString)
                .WithConstructorArgument(GetConnectionString);
            Bind<ITestDb2__Repository>().To<TestDb2__Repository>();
            Bind<ITest__Repository>().To<Test__Repository>();
            Bind<ITest__Business>().To<Test__Business>();
        }
        private string GetConnectionString(IContext context) {
            var cadena = "Test1Connection";
            if (context.Request.Target.Member.DeclaringType.Name.Contains("Repository")) {
                var pr = context.Request.ParentRequest.Target.GetCustomAttributes(typeof(ConnectionAttribute), false);
                cadena = pr.Length == 0 ? "Test1Connection" : ((ConnectionAttribute)pr[0]).ConnectionString;
            }
            if (context.Request.Target.Member.DeclaringType.Name.Contains("Business")) {
                var attrs = context.Request.Target.GetCustomAttributes(typeof(ConnectionAttribute), false);
                cadena = attrs.Length == 0 ? "Test1Connection" : ((ConnectionAttribute)attrs[0]).ConnectionString;
            }
            return cadena;
        }
    }
