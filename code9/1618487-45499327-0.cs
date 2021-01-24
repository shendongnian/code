    using System.Text.RegularExpressions;
    using System.Windows.Automation;
    using TestStack.White.InputDevices;
    using TestStack.White.UIItems;
    using TestStack.White.UIItems.Finders;
    using TestStack.White.UIItems.WindowItems;
    ...
    public class SaveAsWindow
    {
        AutomationElement _dialog;
        Window _win;
        public SaveAsWindow(string title)
        {
            List<Window> winList = TestStack.White.Desktop.Instance.Windows();
            foreach (Window win in winList)
            {
                Regex r = new Regex(title, RegexOptions.IgnoreCase);
                Match m = r.Match(win.Title);
                if (m.Success)
                {
                    _win = win;
                }
            }
            _dialog = _win.GetElement(SearchCriteria.ByControlType(ControlType.Window));
        }
        public void Close()
        {
            Condition condition = new PropertyCondition(AutomationElement.NameProperty, "Cancel");
            AutomationElement noButton = _dialog.FindFirst(TreeScope.Children, condition);
            System.Windows.Point p = noButton.GetClickablePoint();
            Mouse.Instance.Click(p);
        }
        public string FileName
        {
            set
            {
                TextBox fileName =_win.Get<TextBox>(SearchCriteria.ByAutomationId("1001"));
                fileName.Text = value;
            }
        }
        public void Save()
        {
            Condition condition = new PropertyCondition(AutomationElement.AutomationIdProperty, "1");
            AutomationElement saveButton = _dialog.FindFirst(TreeScope.Children, condition);
            System.Windows.Point p = saveButton.GetClickablePoint();
            Mouse.Instance.Click(p);
            System.Threading.Thread.Sleep(1000);
        }
    }
    //// Usage
    IWebDriver driver = new ChromeDriver(@"location chromeDriver", chromeOptions);
    driver.Navigate().GoToUrl(url);
    // it did something and save as window appears.
    var saveWindow = new SaveAsWindow("title of Chrome browser");
    saveWindow.FileName = "c:\what-ever.xlsx";
    saveWindow.Save();
