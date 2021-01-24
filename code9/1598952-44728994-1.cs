    var test = String.Empty;
    
    Assert.AreEqual("", String.Empty);
    Assert.AreEqual("Case 1", "" ?? "Case 1");
    Assert.AreEqual("Case 2", test ?? "Case 2");
    Assert.AreEqual("Case 3", String.Empty ?? "Case 3");
