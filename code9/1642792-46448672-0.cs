    public class MyClassUnderTest {
        private readonly IForceClientProvider provider;
    
        public MyClassUnderTest(IForceClientProvider provider) {
            this.provider = provider;
        }
    
        public async Task<List<string>> GetDeletedRecordIds<T>(DateTime startDate)
            where T : ISalesForceObject {
            List<string> result;
            try {
                var client = await provider.GetForceClient();
                var init = await client.GetDeleted<DeletedRecordRootObject>(typeof(T).Name, startDate, DateTime.Now);
                result = init?.DeletedRecords.Select(d => d.Id).ToList();
            } catch (Exception e) {
                this._logger.LogError(LoggingEvents.GENERAL_ERROR, e, "GetDeletedRecordIds");
                throw;
            }
    
            return result;
        }
    }
