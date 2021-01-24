    public class SizeController : IDataController
    {
        private readonly IDatalayer _datalayer;
    
        public SizeController(Func<ConnType, IDatalayer> dataLayerFactory)
        {
            _datalayer = dataLayerFactory(ConnType.Mssql);
        }
    
        public Response<SizeInfo> GetData(IRequest request)
        {
            //<actions taken here using datalayer>
            _datalayer.SomeIDatalayerMethod();
        }
    }
