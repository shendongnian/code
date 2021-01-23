        [Test]
        [TestCase(10, 5, 15)]
        [TestCase(1, 2, 3)]
        // add your test cases
        public async Task AdditionTests(int a, int b, int result) 
        {
            // Arrange
            var address = "http://localhost:5050";
        
            using (WebApp.Start<Startup>(address))
            {
                var client = new HttpClient();
            
                var requestUri = $"{address}/prefix/{a}?id2={b}";
            
                // Act
                var response = await client.GetAsync(requestUri);
            
                // Assert
                Assert.IsTrue(await response.Content.ReadAsAsync<int>() == result);
            }
        }
