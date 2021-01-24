     class Program
        {
            static void Main(string[] args)
            {
    
                Program  program   =  new Program(); 
                var listBytes  = new List<byte>();
                 var bytes =  program.CastToBytes("test");
                var bdouble = program.CastToBytes(5);  
    
    
            }
    
            public byte[] CastToBytes<T>(T value)            
            {
               
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
