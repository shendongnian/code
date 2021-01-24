    using Newtonsoft.Json;
    // ...
    public class Document
    {
        public string Content1 { get; set; }
        public string Content2 { get; set; }
        // ...
    }
    
    public class MyWireObject
    {
        public string Email { get; set; }
        public Document Document { get; set; }
    }
    
    // ...
    
    HttpRequestMessage httpMessage = new HttpRequestMessage(HttpMethod.Post, "http://localhost");
    MyWireObject myWireObject = new MyWireObject() 
    {
        Email = "user@test.com",
        Document = new Document() 
        {
            Content1 = "content1",
            Content2 = "content2",
            // ...
        }
    };
    
    httpMessage.Content = JsonConvert.SerializeObject(myWireObject);
    
    // ...
    
    string myWireObjectAsString = httpMessage.Content.ReadAsStringAsync().Result;
    // ...
    MyWireObject myWireObject = JsonConvert.DeserializeObject<MyWireObject>(myWireObjectAsString);
