    [Test]
    public void CheckAllElementsArePresent()
    {
        var errors = new List<string>();
        var error = Results.CheckFirstElement();
        if(error != null)
            errors.Add(error);
        error = Results.CheckSecondElement();
        if(error != null)
            errors.Add(error);
        error = Results.CheckThirdElement();
        if(error != null)
            errors.Add(error);
        
        if(errors.Any())
        {
            //Output to console
            var errorString = string.Join(";", errors);
            Console.Writeline(errorString);
            //Fail the test
            Assert.Fail(errorString);
        }
    }
