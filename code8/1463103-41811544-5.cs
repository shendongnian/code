        using System.Windows.Automation; //you need to reference UIAutomationClient and UIAutomationTypes
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetForegroundWindow(IntPtr hWnd);
        private IntPtr _handle;
        //I forget where I got the code of the function below, probably also from stackoverflow. Thanks to the original author!
        private IntPtr getIntPtrHandle(IWebDriver driver, int timeoutSeconds = 30)
        {
            var end = DateTime.Now.AddSeconds(timeoutSeconds);
            while (DateTime.Now < end)
            {
                // Searching by AutomationElement is a bit faster (can filter by children only)
                var ele = AutomationElement.RootElement;
                foreach (AutomationElement child in ele.FindAll(TreeScope.Children, Condition.TrueCondition))
                {
                    if (!child.Current.Name.Contains(driver.Title)) continue;
                    return new IntPtr(child.Current.NativeWindowHandle); ;
                }
            }
            return IntPtr.Zero;
        }
