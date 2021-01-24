            [TestMethod]
            public void ShouldFindOneObject()
            {
                // Given
                var json = @"{""Name"":""Jane Doe"",""Occupation"":""FBI Consultant""}";
                dynamic person = JsonConvert.DeserializeObject(json);
                var people = new[] { person };
    
                // When
                var isMatch = people.Any(p => p.Name == "Jane Doe");
    
                // Then
                Assert.IsTrue(isMatch);
            }
