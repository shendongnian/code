    public class ResponseList<T> {
    
            public ResponseList() {
                Exceptions = new Dictionary<string, string>();
            }
    
            public ResposeCodes ResposeCode { get; set; } = ResposeCodes.Success;
    
            public Dictionary<string, string> Exceptions { get; set; } = null;
    
            public List<T> DataList { get; set; } = null;
    
            public string ResponseMessage { get; set; } = null;
        }
