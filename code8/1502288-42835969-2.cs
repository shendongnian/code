    public class Session
    {
        private static AsyncLocal<IDictionary<string,object>> _Data = new AsyncLocal<Dictionary<string,object>>();
        public static IDictionary Data
        {
            set
            {
                _Data.Value = value;
            }
            get
            {
                return _Data.Value;
            }
        }
    }
