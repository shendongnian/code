      [TestMethod, Isolated]
      public void Test2
      {
          var testFoo = Isolate.Fake.Dependencies<AddFoo>();
          var fooID = Isolate.Invoke.Method(testFoo , "getFooID");
          Assert.IsTrue(fooID is Guid);
      }
