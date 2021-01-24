    public class Program
    {
    
        public int Id { get; set; }
    
        static void Main(string[] args)
        {
            List<Program> client = new List<Program>();
    
            client.Add(new Program { Id = 1 });
            client.Add(new Program { Id = 2 });
            client.Add(new Program { Id = 3 });
            client.Add(new Program { Id = 4 });
            client.Add(new Program { Id = 5 });
    
    
            List<Program> server = new List<Program>();
            server.Add(new Program { Id = 2});
            server.Add(new Program { Id = 4 });
    		List<int> lst = new List<int>();
            foreach (var c in client)
            {
                var r = server.Any(x => x.Id == c.Id);
                if (r==true)
                {
    				lst.Add(c.Id);
                    
                }
    
            }
    		
    		if(lst.Count() > 0)
    			Console.WriteLine(String.Format("Cannot delete as {0} exists",string.Join(",",lst)));    
    
            Console.ReadLine();
        }
    }
