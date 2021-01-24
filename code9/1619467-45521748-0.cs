    class Program
        {
            static void Main(string[] args)
            {
                //I think you know how to read the file so:
                string text = 
    @"12.23.45.56:8080:username:password
    12.23.45.56:8080:username:password
    12.23.45.56:8080:username:password
    12.23.45.56:8080:username:password";
    
                List<ParsedData> ps = new List<ParsedData>();
    
                text.Split(new char[] { '\r','\n' }, StringSplitOptions.RemoveEmptyEntries).ToList().ForEach(c =>
                 {
                     var cols = c.Split(new char[] { ':' }, StringSplitOptions.RemoveEmptyEntries).ToList();
