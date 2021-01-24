    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Newtonsoft.Json.Linq;
    using Newtonsoft.Json;
    namespace SimpleJsonTest
    {
        [TestClass]
        public class JsonObjectTests
        {
            [TestMethod]
            public void ForgiveThisRunOnJsonTestJustShakeYourHeadSayUgghhhAndMoveOn()
            {
                //Need better names than dictName and pName.  Kept it as it is a good approximation of software potty talk.
                string json = "{\"dictName\":\"hello\",\"pName\":\"kitty\"}";
                JObject jsonObject = JObject.Parse(json);
                //Example Zero
                string dictName = jsonObject["dictName"].ToString();
                string pName = jsonObject["pName"].ToString();
                Assert.AreEqual("hello", dictName);
                Assert.AreEqual("kitty", pName);
                //Example One
                MeaningfulName exampleOne = jsonObject.ToObject<MeaningfulName>();
                Assert.AreEqual("hello", exampleOne.DictName);
                Assert.AreEqual("kitty", exampleOne.PName);
                //Example Two (or could just pass in json from above)
                MeaningfulName exampleTwo = JsonConvert.DeserializeObject<MeaningfulName>(jsonObject.ToString());
                Assert.AreEqual("hello", exampleTwo.DictName);
                Assert.AreEqual("kitty", exampleTwo.PName);
            }
        }
        public class MeaningfulName
        {
            public string PName { get; set; }
            [JsonProperty("dictName")] //Change this to suit your needs, or leave it off
            public string DictName { get; set; }
        }
    }
