    public class Foo
    {
         [JsonProperty]
         public string Bar { get; set; }
         [OnError]
         internal void OnError(StreamingContext context, ErrorContext errorContext)
         {
              // specify that the error has been handled
              errorContext.Handled = true;
              // handle here, throw an exception or ...
         }
    }
    int main()
    {
         JsonConvert.SerializeObject(new Foo(), 
                            Newtonsoft.Json.Formatting.None, 
                            new JsonSerializerSettings { 
                                NullValueHandling = NullValueHandling.Ignore
                            });
    }
