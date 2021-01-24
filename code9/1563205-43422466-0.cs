    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
        int ExecuteWithCmd(string command)
        {
            ProcessStartInfo proc = new ProcessStartInfo();
            proc.FileName = @"C:\windows\system32\cmd.exe";
            proc.Arguments = string.Format("/c {0}", command);
            Process newCmdProcess = Process.Start(proc);
            newCmdProcess.WaitForExit();
            return newCmdProcess.ExitCode;
        }
        private void btnAction_Click(object sender, RoutedEventArgs e)
        {
            string shrinksize = "some value?";
            this.ExecuteWithCmd("net start defragsvc");
            this.ExecuteWithCmd("diskpart");
            this.ExecuteWithCmd("sel vol 1");
            this.ExecuteWithCmd("shrink desired =" + shrinksize);
            this.ExecuteWithCmd("exit");
            this.ExecuteWithCmd("exit");
            this.ExecuteWithCmd("net stop defragsvc");
        }
    }
