    public class DataHandler {
        //...other code 
        private DataHandler() {
           
        }
       
        private async Task InitializeAsync(string path) {
            _db = new SQLiteAsyncConnection(path);
            using (await Lock()) {
                await _db.CreateTableAsync<Person>();
                await _db.CreateTableAsync<Animal>();
            }
        }
        public static async Task<DataHandler> CreateDataHandler(string path) {
            var handler = new DataHandler();
            await handler.InitializeAsync(path);
            return handler;
        }
        //...other code 
    }
