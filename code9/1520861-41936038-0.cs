    public static class Locators
    {
        public const string btnUserApply = "btnUserApply";
    }
    public class PageObject
    {
        [FindsBy(How = How.Id, Using = Locators.btnUserApply)]
        public Button ApplyButton { get; set; }
    }
