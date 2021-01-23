     private static Container CreateContainer()
         {
             var container = new Container();
             container.Register<IClient, MyWcfProgram.WcfProgram.Client>();
             container.Register<ILogic, MyWcfProgram.Logic.Logic>();
             container.Register<IData, MyWcfProgram.Data.Data>();
             return container;     
         }
