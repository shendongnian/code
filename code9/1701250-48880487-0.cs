    var dictionary = new Dictionary<string, string>(); // <---- HEEERE
    concreteClassWithADictionaryMock
        .Setup(m => m.Dictionary)
        .Returns(dictionary); // Setting up mock to return a concrete dictionary
    // ...
    concreteClassWithADictionaryMock.Verify(m => m.Dictionary); // A
    concreteClassWithADictionaryMock.VerifyGet(m => m.Dictionary[key]); // B
