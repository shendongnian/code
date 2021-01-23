	CoreAppXmlConfiguration.Instance.RawElementBasedSearch = true;
	CoreAppXmlConfiguration.Instance.MaxElementSearchDepth = 2;
	var applicationDirectory = "D:\\Software\\ABC Handling System";
	var applicationPath = Path.Combine(applicationDirectory, "ABCClient.GUI.exe");
	Application application = Application.Launch(applicationPath);
	Thread.Sleep(5000);
			
    Window window = application.GetWindow("[AB2] - ABC Handling System 2 - [Entity Search]", InitializeOption.NoCache);
	ListBox listbox = window.Get<ListBox>();
	ListItem dispatchButton = listbox.Get<ListItem>(SearchCriteria.ByText("Display"));
	dispatchButton.Click();
	Thread.Sleep(5000);
	UIItemContainer groupbox = window.MdiChild(SearchCriteria.ByControlType(ControlType.Pane).AndIndex(3));
	UIItemContainer pane1 = groupbox.Get<UIItemContainer>(SearchCriteria.ByText("radSplitContainer1"));
	UIItemContainer pane2 = pane1.Get<UIItemContainer>(SearchCriteria.ByText("splitPanel1"));
	Table table = pane2.Get<Table>(SearchCriteria.ByText("Telerik.WinControls.UI.RadGridView ; 247;14")); ;
	TableRow row = table.Rows[9];
	string s = row.ToString();
