    var mDictionary = new Mock<IDictionary<string, string>>();
    mDictionary.Setup(d => d["key"]).Returns("value");
    var mConcrete = new Mock<IClassWithADictionary>();
    mConcrete
        .Setup(m => m.Dictionary)
        .Returns(mDictionary.Object); // Setting up mock to return a mock
    var test = mConcrete.Object.Dictionary[key]; // Getting the value
    // verify if the Dictionary-Itself was read
    mConcrete.Verify(m => m.Dictionary);
    // verify if the Dictionary-Contents was read
    mDictionary.Verify(m => m.Dictionary["key"]);
