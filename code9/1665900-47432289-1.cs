        public class Order
        {
            public Guid Id { get; set; }
    
            [JsonIgnore]
            public Code Code { get; set; }
    
            public string SerializedCode
            {
                get
                {
                    if (Code != null)
                    {
                        return Code.code;
                    }
                    return string.Empty;
                }
            }
    
            public string Title { get; set; }
        }
    Output : {"Id":"227599fe-c834-4330-84e5-2018abe59e35","SerializedCode":"O-123456789","Title":"Test"}
