    public class MyService : IMyService
    {
        private readonly IDataProvider dataProvider;
        public MyService(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;
        }
        public IEnumerable<Instrument> GetInstruments()
        {
            return dataProvider.GetInstruments();
        }
    }
