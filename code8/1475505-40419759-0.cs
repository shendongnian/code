    public static Lapphantering mainForm;        
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main()
    {
        mainForm = new Mainform(); // create instance of Lapphantering
        Application.Run(mainForm);
    }
