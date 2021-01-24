    public class OrderJsonFormatter : BufferedMediaTypeFormatter
        {
            public OrderJsonFormatter()
            {
                SupportedMediaTypes.Add(new MediaTypeHeaderValue("application/json"));
            }
    
            public override bool CanReadType(Type type)
            {
                var canRead = type == typeof(Order);
                return canRead;
            }
    
            public override bool CanWriteType(Type type)
            {
                return false;
            }
    
            public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger)
            {
                return this.ReadFromStream(type, readStream, content, formatterLogger, CancellationToken.None);
            }
    
            public override object ReadFromStream(Type type, Stream readStream, HttpContent content, IFormatterLogger formatterLogger, CancellationToken cancellationToken)
            {
                using (var reader = new StreamReader(readStream))
                {
                    using (var jsonReader = new JsonTextReader(reader))
                    {
                        var jsonSerializer = new JsonSerializer();
    
                        if (type == typeof(Order))
                        {
                           
    
                            try
                            {
                                var entity = jsonSerializer.Deserialize<Order>(jsonReader);
                                return entity;
                            }
                            catch (Exception ex)
                            {
                             //log error here
                                throw;
                            }
                        }
    
                        return null;
                    }
                }
            }
    
         
        }
