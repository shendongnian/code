            [TestMethod]
            public void SouldBindItToCat()
            {
                var sut = new BindingModule(SelectorMode.Cat);
                IKernel kernel = new StandardKernel(sut);
                Assert.IsTrue(kernel.Get<ISound>() is Cat);
            }
     
