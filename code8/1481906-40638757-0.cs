        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<Customer>();
            if(args[0] == "oracle")
                builder.RegisterType<OracleData>().As<Idata>();
            else
                builder.RegisterType<SQLData>().As<Idata>();
            
            var container = builder.Build();
            using (var scope = container.BeginLifetimeScope())
            {
                var app = scope.Resolve<Idata>();
                app.AddData();
            }
            //commented
            //Customer obj = new Customer(new OracleData());
            //obj.Add();
        }
