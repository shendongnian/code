    using System.Runtime.InteropServices;
    using System.Windows;
     
    namespace TestApp
    {
        public partial class MainWindow : Window
        {
            [DllImport("shell32.dll", SetLastError = true)]
            private static extern void SetCurrentProcessExplicitAppUserModelID([MarshalAs(UnmanagedType.LPWStr)] string AppID);
            
            private const string AppID = "73660a02-a7ec-4f9a-ba25-c55ddbf60225"; // generate your own with: Guid.NewGuid();
            
            public MainWindow()
            {
                SetCurrentProcessExplicitAppUserModelID(AppID);
                InitializeComponent();
                Topmost = true; // to make sure UI is in front once
                Topmost = false;
            }
        }
    }
