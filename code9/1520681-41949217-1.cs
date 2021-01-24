    static void Main()
    {
        Application.EnableVisualStyles();
        Application.SetCompatibleTextRenderingDefault(false);
        var formObj = new Form1();
        var hwnd = FindWindow("", "My MDI Title");
        SetParent(formObj.Handle, hwnd);
        Application.Run(formObj);
    }
