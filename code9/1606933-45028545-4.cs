    Assert.Multiple(() =>
    {
        foreach (SomeEntity someEntity in outerCollection)
        {
            Assert.AreEqual(innerCollectionSize, someEntity.InnerCollection.Count);
        }
    });
