    class Program
    {
        public static SharedData Shared {get; set;}
        [STAThread]
        static void Main()
        {
            Shared = new SharedData();
            Shared.TestData.Add("test1");
            Shared.TestData.Add("test2");
            Shared.TestData.Add("test3");
            System.Windows.Forms.Application.EnableVisualStyles();
            System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
            System.Windows.Forms.Application.Run(new Form1());
        }
    }
