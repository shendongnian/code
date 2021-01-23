      [TestMethod]
            public void TestMethod1()
            {
                var mock = Isolate.Fake.Instance<Test>();
                Isolate.WhenCalled(() => mock.DoSomethingStringy(null)).DoInstead(contaxt =>
                {
                    return (contaxt.Parameters[0] as string).ToLower();
                });
    
                var res = mock.DoSomethingStringy("SOMESTRING");
    
                Assert.AreEqual("somestring", res);
            } 
 
