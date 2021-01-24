    public Form1()
        {
            InitializeComponent();
            uiButton1.ButtonStyle = Janus.Windows.EditControls.ButtonStyle.DropDown;
            var menu = new Janus.Windows.UI.CommandBars.UIContextMenu();
            menu.Commands.Add(new Janus.Windows.UI.CommandBars.UICommand("1", "Item1"));
            menu.Commands.Add(new Janus.Windows.UI.CommandBars.UICommand("2", "Item2"));
            uiButton1.DropDownContextMenu = menu;
        }
