    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        IInterfaceTasks interfaceTasks = new **SOME CLASS THAT IMPLEMENTS IInterfaceTasks**
        Application.Run(new pws(interfaceTasks));
    }
