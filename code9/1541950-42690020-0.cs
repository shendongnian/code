        [TestMethod]
        public void App_Handles_Exceptions()
        {
          var app = new App();
          var dapp = (DispatcherObject)app;
          var mi = typeof(Dispatcher).GetMethod("CatchException", BindingFlags.Instance | BindingFlags.NonPublic);
          var handled = (bool)mi.Invoke(dapp.Dispatcher, new object[] { new Exception("a") });
    
          Assert.IsTrue(handled);
        }
