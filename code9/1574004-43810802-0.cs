    namespace ImageTests
    {
        [TestClass]
        public class UnitTest1 {
            [TestMethod]
            public async Task TestImagefromURL() {
                Debug.WriteLine("Test was loaded");
                var instance = new Manager();
                var client = instance.StartMyTask();
                Debug.WriteLine("Caption: " + client.Description.Captions[0].Text);
            }
        }
    }
