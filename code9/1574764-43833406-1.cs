      public class Program
        {
           public  delegate void myC1(string myStr); 
            static void Main(string[] args)
            {
                myC1 meth = new Program().MethodToInvoke;  
                 myProc1(meth,"test invoke");                             
            }                  
            public void MethodToInvoke( string str )
            {
                Console.WriteLine("test");                    
            }
    
            public static void myProc1(myC1 method, string mystring)    
            {                
                method(mystring);  
                //this will print test                     
            }    
        }
