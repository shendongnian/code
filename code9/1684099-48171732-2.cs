    public interface IMetaDataSaverFactory
    {
        IMetaDataSaver GetMetaDataFactory(HttpRequestMessage request);
    }
    public class MetaDataSaverFactory : IMetaDataSaverFactory
    {
        private IEmployerFunctions _functions;
        public MetaDataSaverFactory(IEmployerFunctions functions)
        {
            _functions = functions;
        }
        public static IMetaDataSaver GetMetaDataFactory(HttpRequestMessage request)
        {
            if (request.IsReciprocal())
            {
                return new ReciprocalMetaDataSaver();
            }
            else
            {
                return new EmployerMetaDataSaver(_functions); 
            }
        }
    }
