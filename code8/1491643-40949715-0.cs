    public class Writer : IDisposable
    {
        public void Dispose()
        {
                
        }
    
        public void Write(string s)
        {
            Console.WriteLine(s);
        }
    } 
    class Program
    {
    
        static void Main(string[] args)
        {
            Writer writer = new Writer();
            writer.Write("1");
            writer.Dispose();
    
            // writer will still be around because I am referencing it (rooted)
            writer.Write("2");
    
            GC.Collect();
    
            // calling GC.Collect() has no impact since writer is still rooted
            writer.Write("3");
            Console.ReadKey();
    
        }
    }
