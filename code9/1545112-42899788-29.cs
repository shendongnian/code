    // these 2 values will do the binding
    public static readonly Guid ApplicationCommands
                                      = new Guid("00000000-0000-0000-0000-000000000002");
    public const int SaveCommandId = 0x0201;
    private readonly Package package;
    private CommandName(Package package)
    {
        // we need to have package (from Initialize() method) to set VS
        if (package == null) throw new ArgumentNullException("package");
        this.package = package;
        // this provides access for the Menu (so we can add our Command during init)
        OleMenuCommandService commandService = this.ServiceProvider.GetService(typeof(IMenuCommandService)) as OleMenuCommandService;
        if (commandService != null)
        {
            // Creates new command "reference" (global ID)
            var menuCommandID = new CommandID(ApplicationCommands, SaveCommandId);
            // Create new command instance (method to invoke, ID of command)
            var menuItem = new MenuCommand(this.Save, menuCommandID);
            // Adding new command to the menu
            commandService.AddCommand(menuItem);
        }
        private void Save()
        {
            // Get instance of our window object (param false -> won't create new window)
            ToolWindowPane lToolWindow = this.package.FindToolWindow(typeof(MyToolWindow), 0, false);
            if ((null == lToolWindow) || (null == lToolWindow.Frame)) return;
            // Handle the toolWindow's content as Window (our control)
            ((lToolWindow as MyToolWindow)?.Content as MyWindowControl)?.Save();
        }
    }
