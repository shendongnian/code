    //Arrange
    var client = new HttpClient { BaseAddress = new Uri("http://localhost:55442/") 
                                };
    client.DefaultRequestHeaders.Add("access_token", "YWtoaWw6YWtoaWw=");
    Employee emp = new Employee {
                Id=1,
                name = "Test Name",
                salary = "2000"
            };
    //Act
    var _response = 
    client.PostAsJsonAsync(client.BaseAddress +"/"+ "myController"+ "/"+ 
                           "methodName",emp).Result;
    
    //Assert
    Assert.IsTrue(true);
