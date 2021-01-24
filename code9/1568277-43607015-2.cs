            public byte[] CastToBytes<T>(T value)            
            {
                //this will cover most  of primitive types 
               
                if (typeof(T).IsValueType)
                {
                    return BitConverter.GetBytes((dynamic)value);
                }
    
                if (typeof(T) == typeof(string))
                {
                    return Encoding.UTF8.GetBytes((dynamic) value); 
                }
                //for a custom  object  you  have to  define  the rules 
                else
                {
                    var formatter = new BinaryFormatter();
                    var memoryStream = new MemoryStream();
                    formatter.Serialize(memoryStream, value);
                    return  memoryStream.GetBuffer();     
                }                                    
            }
    
        }
