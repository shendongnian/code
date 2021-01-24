    string notificationText = NotificationText(story, profile);
    TestData testData = new TestData { Data = new Data { Message = notificationText }};
            
    var payload = JsonConvert.SerializeObject(testData).ToLowerInvariant();
     public class TestData
     {
           public Data Data;
     }
    
     public class Data
     {
          public string Message;
     }
