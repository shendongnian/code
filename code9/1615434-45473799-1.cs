    public class WinRibbon : WinControl
    {
        protected WinMenuBar RibbonBarInside {
            get
            {
                var ribbonBarInside = new WinMenuBar(this.RibbonBar);
                ribbonBarInside.SearchConfigurations.Add(WinControl.PropertyNames.Name, "radRibbonBar");
                return ribbonBarInside;
            }
        }
        public IEnumerable<WinTabPage> Tabs => new WinTabPage(this.RibbonBarInside).FindMatchingControls().OfType<WinTabPage>();
        public WinControl FileTab => this.Tabs.FirstOrDefault(t => t.AccessibleDescription.Trim() == "File");
        public IEnumerable<WinButton> Buttons => new WinButton(this.RibbonBarInside).FindMatchingControls().OfType<WinButton>();
        public WinButton OpenButton => this.Buttons.FirstOrDefault(t => t.AccessibleDescription.Trim() == "Open");
        public WinRibbon(UITestControl parent = null) : base(parent)
        {
            this.SearchProperties.Add(WinControl.PropertyNames.ControlName, "radRibbonBar");
        }
        public void ClickOpenButton()
        {
            var openButton = this.OpenButton; // to prevent creating a new one each time
            Mouse.Location = new Point(openButton.Left + openButton.Width / 2, openButton.Top + openButton.Height / 2);
            Mouse.Click();
        }
    }
