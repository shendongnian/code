    public class Element: IWebElement 
    {
        IWebElement realElement;
        public bool Visible {get; set;}
        public Element() : base()
        {
            realElement = webDriver.FindElement(...);
            Visible = element.Visible;
        } 
    }
