        public class MyModelClass
        {
            ...
            [JsonIgnore]
            public string SecondField { get; set; }
            [JsonProperty("second_field")]
            private string UrlEncodedSecondField
            {
                get { return System.Web.HttpUtility.UrlEncode(SecondField); }
            }
            ...
        }
