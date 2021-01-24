    private IWebElement GetAnswerElement(string questionText, string answerText)
    {
        var xpath = String.Format(
                        "//div[@id='client-assessment']/div/div/label/input[@id='{0}'][@value='{1}']", 
                        questionText, 
                        answerText);
        return BrowserFactory.Driver.FindElement(By.XPath(xpath));
    }
    var element = GetAnswerElement(
                      "Product_Contractor_ClientAssessment_Question06",
                      "Answer1");
