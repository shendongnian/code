    public class Core
    {
        protected CorePage CurrentPage
        {
            get
            {
                return ScenarioContext.Current.Get<CorePage>("CurrentPage";
            }
            set
            {
                ScenarioContext.Current["CurrentPage"] = value;
            }
        }
        public TPage InstanceOf<TPage>() where TPage : CorePage, new()
        {
            return new TPage();
        }
        public TPage As<TPage>() where TPage : CorePage
        {
            return (TPage) this;
        }
    }
    public class CorePage : Core
    {
        //Base page class
    }
    public class HomePage : CorePage
    {
        public void OpenLogin()
        {
            //Code 
            CurrentPage = new LoginPage();
        }
    }
    public class LoginPage : CorePage
    {
        public void Something()
        {
            //Code
        }
    }
    [Binding]
    public class Step : Core
    {
        [Given(@"1st step")]
        public void BlaBlaBla1()
        {            
            CurrentPage.InstanceOf<HomePage>().OpenLogin();
        }
        [Then(@"2nd step")]
        public void BlaBlaBla2()
        {
            CurrentPage.As<LoginPage>().Something();
        }
    }
