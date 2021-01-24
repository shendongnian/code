    var expectedTopNavClassName = "container-fluid";
    var topNavElement = Driver.Instance.FindElement(By.Id("..."));
    var topNavClassName = topNavElement.GetAttribute("class");
    
    Console.WriteLine($"The variable topNavClassName contains the value: {topNavClassName}");
    if (topNavClassName != expectedTopNavClassName)
    {
        throw new Exception("...");
    }
