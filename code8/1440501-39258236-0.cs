           //Arrange
           Client myTestClient = null;
           string expectedValue = String.Empty;
           string expectedKey = COMPANY_NAME;
           
           //Act
           Dict actual = contentService.getOrder(myTestClient);
           //Assert
           Assert.IsTrue(actual.ContainsKey(expectedKey));
           Assert.IsTrue(actual.ContainsValue(expectedValue));
       }
