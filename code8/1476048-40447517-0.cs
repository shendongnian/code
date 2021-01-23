      [TestMethod]
            public void NullCheck()
            {
                try
                {
                    var contactPage = Isolate.Fake.Instance<Contact>();
                    TestHandlerDemoClass t = new TestHandlerDemoClass();
                    t.MyTestMethod(contactPage);
                }
                catch (Exception ex)
                {
                    Assert.AreEqual(ex.Message, "Id not found");
                }
            }
