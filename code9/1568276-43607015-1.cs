     class Program
        {
            static void Main(string[] args)
            {    
                Program  program   =  new Program(); 
                var listBytes  = new List<byte>();
                   listBytes.Add( program.CastToBytes("test")); 
                   listBytes.Add(program.CastToBytes(5));         
            }
