    [TestMethod]
    public void GetTerm_FromGetTerm()
    {
        var controller = new ServController();
        
        using (ShimsContext.Create())
        {
            MyAssembly.Fakes.ShimInteractionController.GetTermsAndConds = () => SomeCannedResponse();
            IHttpActionResult actionResult = controller.GetTerm();
            var result = controller.GetTerm(); // Why do you call GetTerm twice?!
            Assert.IsNotNull(actionResult);
        }
    }
