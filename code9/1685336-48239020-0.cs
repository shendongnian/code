    namespace MyNamespace
    {
        public class Program
        {
            public static void Main(string[] args)
            {
              var m="this is mystring";
    
              var b = new char [m.Length];
    
    
              var j=0;
                //Your code goes here
              for (int i = m.Length - 1; i >= 0; i--)
              {
                  b[j]=m[i];
                  j++;
                  if(m[i]==' ' || i==0)
                 {
                    if(i==0)
                    {
                       b[j]=' ';
                    }
                    for (int x = b.Length - 1; x >= 0; x--)
                   {
               
                       Console.Write(b[x]);
               
                  }
                  b=new char[m.Length];
                  j=0;
               }
    
            } 
              Console.ReadKey();
               Console.WriteLine("Hello, world!");
            }
        }
    }
