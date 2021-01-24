    [Serializable]
        public class MyException : Exception
        {
            public MyException() { }
            public MyException( string message ) : base( message ) { }
            public MyException( string message, Exception inner ) : base( message, inner ) { }
            
            protected MyException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context ) : base( info, context ) { }
        }
    
        class Program {
            static void Main(string[] args) {
                try{
                    throw new MyException("Whoops#1");
                    //throw new MyException("Fubar#2");
                }catch(MyException myEx){
                    string aExMsg = myEx.Message;
                    if (aExMsg.Contains("#1")){
                        Console.WriteLine("Whoops was caught");
                    }
                    if (aExMsg.Contains("#2")){
                        Console.WriteLine("Fubar was caught");
                    }
                }catch (Exception ex){
                    throw;
                }
                Console.Write("Press <ENTER> to continue...");
                Console.ReadLine();
            }
        }
