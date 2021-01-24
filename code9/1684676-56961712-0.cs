        [Test]
        public void Test_Foo()
        {            
            // filter test
            switch (GlobalDefinitions.Category)
            {
                    // OK Test
                    case Category.Oracle:
                    case Category.SQL:
                        break;
                    // Do NOT test
                    case Category.MongoDb:
                        Assert.Inconclusive();
                    // Error
                    default:
                        Assert.Fail("Not implemented case");
            }
            // perform test...
        }
