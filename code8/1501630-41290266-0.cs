    var criteria = new Dictionary<string, bool>{
        {"oneCriterion", true},
        {"anotherOne", true},
        {"andAnotherOne", true}
    };
    
    //true!
    var masterCriteria = criteria.All(x => x.Value);
    Assert.IsTrue(masterCriteria);
    
    criteria.Remove("oneCriterion");
    criteria.Add("newCriterion", false);
    
    //false
    masterCriteria = criteria.All(x => x.Value);
    Assert.IsFalse(masterCriteria);
