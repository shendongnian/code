     static void Main(string[] args)
        {
            var unityContainer = new UnityContainer();
            unityContainer.RegisterType<IDataAccessLayer, DataAccessLayer>();
            var instancerOfDataAccessLayer = unityContainer.Resolve<IDataAccessLayer>();
            instancerOfDataAccessLayer.Foo();
            Console.ReadLine();
        }
