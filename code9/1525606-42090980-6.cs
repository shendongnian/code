    [TestClass]
    public class MyController
    {
        [TestMethod]
        public void TestMyControllerActionSaveData()
        {  
             var client = new ClientHandler();
             var content = new StringContent(dataHere, Encoding.UTF8, "application/json");
             var outPut = client.Post("http://server/action/here", content).Result;
             // validate expected output here
        }
    }
