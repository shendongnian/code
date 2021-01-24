    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            bool registered = FunctionThatChecksSerialNumber();
            if (registered)
            {
                Application.Run(new Form1());
            }
            else
            {
                Application.Run(new TrialCheck());
            }
        }
    }
