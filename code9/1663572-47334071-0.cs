    public class CoreBarCodeDTO
    {
        private string _json;
        public string json { get { return _json; }
            set {
                string decoded = HttpUtility.UrlDecode(value);
                _json = decoded;
            }
        }
    }
