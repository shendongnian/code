    class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            TextboxInfo[] info = new TextboxInfo[2];
            info[0] = new TextboxInfo(150, 14, 20, 32, "This is a TextBox 1");
            info[1] = new TextboxInfo(180, 34, 40, 52, "This is a TextBox 2");
            TextForm frm = new TextForm(info);
            frm.ShowDialog();
            // Now you can access the form's text box values through frm.TextBoxes[i].Text
        }
    }
