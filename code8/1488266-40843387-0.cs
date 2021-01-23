        [Test]
        public void WhenCorrectUrlIsPassedConnectionCreatedSuccessfully()
        {
            Connection testConnection = new Connection();
            connection.CreateConnection(correctURL, IDName + connection.ApiKey, connection.ContentType, connection.MediaType, connection.Get, false, "name");
        }
        [Test]
        [ExpectedException(typeof(WebException))]
        public void WhenIncorrectUrlIsPassedThenWebExceptionIsThrown()
        {
            Connection connection = new Connection();
            Assert.Catch<WebException>(() => connection.CreateConnection("test", IDName + connection.ApiKey, connection.ContentType, connection.MediaType, connection.Get, false, "name"););
        }
