    [TestFixture("My String")]
    public class When_Working_Up_A_Storm
    {
        public When_Working_Up_A_Storm(string myString)
        {
            _myString = myString;
        }
        private string _myString;
        
        [Test]
        public void Magic_Happens()
        {
            Assert.AreEqual("My String", _myString);
        }
    }
