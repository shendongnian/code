    public class ApiClient : IDisposable 
    {  
        private readonly HttpClient http = new HttpClient();
        public void Dispose()
        {  
            Dispose(true);  
            GC.SuppressFinalize(this);  
        }  
        protected virtual void Dispose(bool disposing)
        {  
            if (disposing)
            {
                http?.Dispose();  
            }  
        }  
    }
