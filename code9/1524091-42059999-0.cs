    class Program
    {
        private static IUnityContainer _container;
        static void Main(string[] args)
        {
            var boot = new Bootstrapper();
            boot.Run();
            _container = boot.Container;
            InitMaps(_container);
            var dto = new Dto {Id = 418, Name = "Abrahadabra"};
            var model = Mapper.Map<ViewModel>(dto);
        }
        private static void InitMaps(IUnityContainer container)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Dto, ViewModel>()
                    .ConstructUsing(f => UnityObjectFactoty.GetInstance<ViewModel>(container));
            });
        }
    }
