    public class DataProvider : IDataProvider(){
  
        private string _path = "";
        public GetPath()
        {  
            if (string.IsNullOrEmpty(_path))
            {
                // You could return a hard-coded value, like this, or fetch
                // data in a more flexible way (config? DB? Web-service? ...?)
                _path = @"C:\..."; 
            }
            return _path;
        }
    }
