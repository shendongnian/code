    //Act
    service.AddPolicy(new Policies {PolicyID = 3, PolicyName = "policy2", PolicyDesc = "pDesc3"});
    service.AddPolicy(new Policies { PolicyID = 4, PolicyName = "policy2", PolicyDesc = "pDesc3" });
    ///Assert
    var expected = 3;
    //first, can I know how many object I have the policy name "policy2".
    var actual = mockSetPolicies.Object.Count(p => p.PolicyName == "policy2");
    //second, can I assert the number of objects I have currently with the name "policy2".
    Assert.AreEqual(expected, actual);
