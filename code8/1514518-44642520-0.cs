        public static async Task<string> getInput()
        {
             using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString()))
             {
                 content.Add(new StreamContent(new MemoryStream(Encoding.ASCII.GetBytes("your data"))), 
                                                  "file", "upload.xml");
              
                 var input = await content.ReadAsStringAsync();
                 
                 return input;
             }
            
            return null;
        }
        
        public static void Main(string[] args)
        {
             Console.WriteLine(getInput().Result);
        }
