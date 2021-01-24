    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            ShowForms();
            Application.Run();
        }
        public static void RepeatAction(int repeatCount, Action action)
        {
            for (int i = 0; i < repeatCount; i++)
                action();
        }
        static void ShowForms()
        {
            Random random = new Random();
            int formCount = 0;
            RepeatAction(10, () =>
            {
                formCount++;
                int x = random.Next(0, 100);
                int y = random.Next(0, 100);
                Form1 form = new Form1
                {
                    StartPosition = FormStartPosition.Manual,
                    ShowInTaskbar = false,
                    Location = new Point(x, y)
                };
                form.FormClosed += (sender, e) =>
                {
                    if (--formCount > 0)
                    {
                        return;
                    }
                    Application.ExitThread();
                };
                form.Show();
            });
        }
    }
