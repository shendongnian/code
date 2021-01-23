        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Form f = new Form();
            f.controls.Add(new MasterLogin());
            Application.Run(f);
        }
