    static void Main(string[] args)
       {
           Task<string> t = HttpGetResponse();
         
          //Do alot of work
           t.Wait();
           string response = t.Result;
           Console.WriteLine(response);
       }
