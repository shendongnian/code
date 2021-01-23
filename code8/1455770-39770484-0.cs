     [TestClass]
     public class Test2
     {
        [TestMethod]
        public void Test()
        {
            var item = JsonConvert
                .DeserializeObject<Payload>("{\"data\":{\"UserID\":\"MS100000041\",\"RoleID\":5}}")
                .data;
            Assert.AreEqual(item.RoleID, 5);
            Assert.AreEqual(item.UserID, "MS100000041");
        }
        class Payload
        {
            public UserDetails data { get; set; }
        }
        class UserDetails
        {
            public int RoleID { get; set; }
            public string UserID { get; set; }
        }
     }
