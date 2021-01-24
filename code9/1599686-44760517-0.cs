    public class GenericPage
    {
       public virtual void Proceed(string testName)
       {
         //Basic implementation
       }
    }
    public class WhatIsYourNamePage : GenericPage
    {
        [FindsBy(How = How.Id, Using = "fieldName")]
        [CacheLookup]
        private IWebElement UserName { get; set; }
    
        [FindsBy(How = How.Id, Using = "fieldSurname")]
        [CacheLookup]
        private IWebElement UserSurname { get; set; }
    
        [FindsBy(How = How.Id, Using = "submit-first-inner-1")]
        [CacheLookup]
        private IWebElement Submit { get; set; }
    
        public override void Proceed(string testName)
        {
            var userData = ExcelDataAccess.GetTestData(testName);
            UserName.EnterText(userData.fieldName, Costants.UserNameElementName);
            UserSurname.EnterText(userData.fieldSurname, Costants.SurnameElementName);
            Thread.Sleep(5000);
            Submit.ClickOnIt(Costants.SubmitButtonElementName);
            Thread.Sleep(5000);
        }
    }
