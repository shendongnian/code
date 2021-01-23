        public static async Task<string> getInput()
        {
             var input = "";
            
             using (var content = new MultipartFormDataContent("Upload----" + DateTime.Now.ToString()))
             {
                 content.Add(new StreamContent(new MemoryStream(Encoding.ASCII.GetBytes("your data"))), 
                                                  "file", "upload.xml");
              
                 input = await content.ReadAsStringAsync();
                
             }
            
            return input;
        }
        
        public static void Main(string[] args)
        {
             Console.WriteLine(getInput().Result);
        }
