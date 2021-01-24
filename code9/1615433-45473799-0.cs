    public class WinRibbon : WinControl
    {
        protected WinWindow RibbonBar
        {
            get
            {
                var ribbonBar = new WinWindow(this.Container);
                ribbonBar.SearchProperties.Add(WinControl.PropertyNames.ControlName, "radRibbonBar");
                return ribbonBar;
            }
        }
        protected WinMenuBar RibbonBarInside {
            get
            {
                var ribbonBarInside = new WinMenuBar(this.RibbonBar);
                ribbonBarInside.SearchConfigurations.Add(WinControl.PropertyNames.Name, "radRibbonBar");
                return ribbonBarInside;
            }
        }
        protected WinTabPage Tabs => new WinTabPage(this.RibbonBarInside);
        protected WinControl FileTab => this.Tabs.FindMatchingControls().OfType<WinTabPage>().FirstOrDefault(t => t.AccessibleDescription.Trim() == "File");
        protected WinButton Buttons => new WinButton(this.RibbonBarInside);
        protected WinButton OpenButton => this.Buttons.FindMatchingControls().OfType<WinButton>().FirstOrDefault(t => t.AccessibleDescription.Trim() == "Open");
        public WinRibbon(UITestControl parent = null) : base(parent)
        {
        }
        public void ClickOpenButton()
        {
            var openButton = this.OpenButton; // to prevent creating a new one each time
            Mouse.Location = new Point(openButton.Left + openButton.Width / 2, openButton.Top + openButton.Height / 2);
            Mouse.Click();
        }
    }
