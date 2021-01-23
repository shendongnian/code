    // Create the web request (posts/1)
    HttpWebRequest request = WebRequest.Create("https://jsonplaceholder.typicode.com/posts/1") as HttpWebRequest;
    // Get response  
    using (HttpWebResponse response = request.GetResponse() as HttpWebResponse)
    {
       // Get the response stream  
       StreamReader reader = new StreamReader(response.GetResponseStream());
    
       {
           //string myString = reader.ReadToEnd();
           //System.IO.File.WriteAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\WriteText.json", myString);
       }
    
    
       // JSON deserialize from a file
       // String JSONstring = File.ReadAllText(@"C:\Users\admin\Documents\Visual Studio 2015\Projects\WriteText.json");
       //  List<PARSE> pList = JsonConvert.DeserializeObject<List<PARSE>>(JSONstring);
       PARSE pList = JsonConvert.DeserializeObject<PARSE>(reader.ReadToEnd());
       reader.close();
