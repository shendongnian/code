    //Act
    service.AddPolicy(new Policies {PolicyID = 3, PolicyName = "policy2", PolicyDesc = "pDesc3"});
    service.AddPolicy(new Policies { PolicyID = 4, PolicyName = "policy2", PolicyDesc = "pDesc3" });
    ///Assert
    var expected = 3;
    var actual = mockSetPolicies.Count(p => p.PolicyName == "policy2");
    Assert.AreEqual(expected, actual);
