      List<Users> mockList = new List<Users>()
      {
          new Users
          {
              User = 1,
              FirstName = "TestFirstName",
              LastName = "TestLastName",
              Group = "CEO"
          }
      };
      mockRepository
     .Setup(x => x.GetCEOs())
     .Returns(mockList);
