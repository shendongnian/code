    public class SizeController : IDataController
    {
        private readonly Func<ConnType, IDatalayer> _dataLayerFactory;
        private readonly IDatalayer _datalayer;
    
        public SizeController(Func<ConnType, IDatalayer> dataLayerFactory)
        {
             //What ever combination you choose
            _dataLayerFactory = dataLayerFactory;
            _datalayer = dataLayerFactory(ConnType.Mssql);
        }
    
        public Response<SizeInfo> GetData(IRequest request)
        {
            //<actions taken here using datalayer>
            _datalayer.SomeIDatalayerMethod();
            // or call it directly
            //dataLayerFactory(ConnType.Mssql).SomeIDatalayerMethod();
        }
    }
