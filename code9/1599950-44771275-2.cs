    using Newtonsoft.Json;
    // First define the classes you will need ...
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
    
    // Later, create an instance and serialize it as the body of your request ...
    
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
    
    // Later in the POST handler ...
    
    string myWireObjectAsString = httpMessage.Content.ReadAsStringAsync().Result;
    // Or even better ...
    MyWireObject myWireObject = JsonConvert.DeserializeObject<MyWireObject>(myWireObjectAsString);
    // And use the object ...
    
