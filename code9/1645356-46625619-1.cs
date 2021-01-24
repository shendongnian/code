    public class Program
    {
        public static void Main(string[] args)
        {
            string json = @"
            {
              ""company_webhooks"": [
                {
                  ""company_webhook"": {
                    ""id"": 42,
                    ""url"": ""https://keeptruckin.com/callbacktest/842b02"",
                    ""secret"": ""fe8b75de0a4e5898f0011faeb8c93654"",
                    ""format"": ""json"",
                    ""actions"": [
                      ""vehicle_location_received"",
                      ""vehicle_location_updated""
                    ],
                    ""enabled"": false
                  }
                },
                {
                  ""company_webhook"": {
                    ""id"": 43,
                    ""url"": ""https://keeptruckin.com/callbacktest/a6a783"",
                    ""secret"": ""66a7368063cb21887f546c7af91be59c"",
                    ""format"": ""json"",
                    ""actions"": [
                      ""vehicle_location_received"",
                      ""vehicle_location_updated""
                    ],
                    ""enabled"": false
                  }
                },
                {
                  ""company_webhook"": {
                    ""id"": 44,
                    ""url"": ""https://keeptruckin.com/callbacktest/53a52c"",
                    ""secret"": ""4451dc96513b3a67107466dd2c4d9589"",
                    ""format"": ""json"",
                    ""actions"": [
                      ""vehicle_location_received"",
                      ""vehicle_location_updated""
                    ],
                    ""enabled"": false
                  }
                },
                {
                  ""company_webhook"": {
                    ""id"": 45,
                    ""url"": ""https://keeptruckin.com/callbacktest/6fb337"",
                    ""secret"": ""4177fbd88c30faaee03a4362648bd663"",
                    ""format"": ""json"",
                    ""actions"": [
                      ""vehicle_location_received"",
                      ""vehicle_location_updated""
                    ],
                    ""enabled"": false
                  }
                },
                {
                  ""company_webhook"": {
                    ""id"": 46,
                    ""url"": ""https://keeptruckin.com/callbacktest/8cd6da"",
                    ""secret"": ""6e41817a048b009435e5102fca17db55"",
                    ""format"": ""json"",
                    ""actions"": [
                      ""vehicle_location_received"",
                      ""vehicle_location_updated""
                    ],
                    ""enabled"": false
                  }
                }
              ],
              ""pagination"": {
                ""per_page"": 25,
                ""page_no"": 1,
                ""total"": 5
              }
            }";
            var settings = new DataContractJsonSerializerSettings();
            settings.DataContractSurrogate = new MyDataContractSurrogate();
            settings.KnownTypes = new List<Type> { typeof(Dictionary<string, Dictionary<string, object>>) };
            settings.UseSimpleDictionaryFormat = true;
            KeepTruckinResponse response = Deserialize<KeepTruckinResponse>(json, settings);
            foreach (KeepTruckinCompanyWebHook wh in response.WebHooks)
            {
                Console.WriteLine("Id: " + wh.Id + ", Url: " + wh.Url);
            }
        }
        public static T Deserialize<T>(string json, DataContractJsonSerializerSettings settings)
        {
            using (MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
            {
                var ser = new DataContractJsonSerializer(typeof(T), settings);
                return (T)ser.ReadObject(ms);
            }
        }
        public static string Serialize(object obj, DataContractJsonSerializerSettings settings)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                var ser = new DataContractJsonSerializer(obj.GetType(), settings);
                ser.WriteObject(ms, obj);
                return Encoding.UTF8.GetString(ms.ToArray());
            }
        }
    }
    [DataContract]
    public class KeepTruckinResponse
    {
        [DataMember(Name = "company_webhooks", EmitDefaultValue = false)]
        public KeepTruckinCompanyWebHook[] WebHooks { get; set; }
    
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public KeepTruckinPagination Pagination { get; set; }
    
        public string RawJSON { get; set; }
    }
    
    [DataContract]
    public class KeepTruckinPagination
    {
        [DataMember(Name = "per_page", EmitDefaultValue = false)]
        public int PerPage { get; set; }
    
        [DataMember(Name = "page_no", EmitDefaultValue = false)]
        public int PageNumber { get; set; }
    
        [DataMember(Name = "total", EmitDefaultValue = false)]
        public int Total { get; set; }
    }
    
    [DataContract(Name = "company_webhook")]
    public class KeepTruckinCompanyWebHook
    {
        [DataMember(Name = "id", EmitDefaultValue = false)]
        public int Id { get; set; }
    
        [DataMember(Name = "url", EmitDefaultValue = false)]
        public string Url { get; set; }
    }
