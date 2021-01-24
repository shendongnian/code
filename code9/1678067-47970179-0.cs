      [TestMethod, Isolated]
      public void Test1
      {
          var testFoo = Isolate.Fake.Dependencies<AddFoo>();
          var newGuid = new Guid();
          testFoo.FooId = Guid.NewGuid()
          Isolate.Verify.NonPublic.Property.WasCalledSet(testFoo, "FooId").WithArgument(newGuid);
      }
