    [TestMethod]
    public void App_Handles_Exceptions_WithFakes()
    {
      using (ShimsContext.Create())
      {
        string usedMessage = null;
        string usedError = null;
        System.Windows.Fakes.ShimMessageBox.ShowStringStringMessageBoxButtonMessageBoxImage = (s, s1, arg3, arg4) =>
          {
            usedMessage = s;
            usedError = s1;
            return MessageBoxResult.OK;
          };
        var app = new App();
        var dapp = (DispatcherObject)app;
        var mi = typeof(Dispatcher).GetMethod("CatchException", BindingFlags.Instance | BindingFlags.NonPublic);
        var handled = (bool)mi.Invoke(dapp.Dispatcher, new object[] { new Exception("a") });
        Assert.IsTrue(handled);
        Assert.AreEqual("a\"", usedMessage);
        Assert.AreEqual("Error", usedError);
      }
    }
