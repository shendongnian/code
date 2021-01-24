    public class MyData 
    {
        public string Bla { get; set; } 
    }
    // create an instance
    MyData myData = new MyData()
    {
        Bla = "the value";
    };   
    // then use it
    Message response = Message.CreateMessage(
                                 MessageVersion.None,
                                 "*",
                                 myData, 
                                 new DataContractJsonSerializer(typeof(MyData)));
        
