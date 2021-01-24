    var mainWindow = new WinWindow(app);
    mainWindow.SearchProperties.Add(WinWindow.PropertyNames.ControlName, "frmMain");
    var ribbonBar = new WinWindow(mainWindow);
    ribbonBar.SearchProperties.Add(WinWindow.PropertyNames.ControlName, "radRibbonBar");
                
    var ribbonBarInside = new WinMenuBar(ribbonBar);
    ribbonBarInside.SearchProperties.Add(WinWindow.PropertyNames.Name, "radRibbonBar");   //Name not ControlName!!
    Assert.IsTrue(ribbonBarInside.TryFind());
                
    var tabs = new WinTabPage(ribbonBarInside);
    var tab = tabs.FindMatchingControls().Where(t => (t as WinTabPage).AccessibleDescription.Trim() == "File").FirstOrDefault();
    Assert.IsNotNull(tab);
    Mouse.Click(tab);
    
    var buttons = new WinButton(ribbonBarInside);
    var button = buttons.FindMatchingControls().Where(t => (t as WinButton).AccessibleDescription.Trim() == "Open").FirstOrDefault();
    Assert.IsNotNull(button);
    //Mouse.Click(button);   <-- this throw an Exception, next 2 lines solve this.
    Mouse.Location = new Point(button.Left + button.Width / 2, button.Top + button.Height / 2);
    Mouse.Click();
