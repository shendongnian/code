    interface ISomeInterface
    {
        void Configure();
    }
    class SomeType : ISomeInterface
    {
        public void Configure()
        {
            var windowsService = new ServiceController("msdtc");
            windowsService.Start();
        }
    }
