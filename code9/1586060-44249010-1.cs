    using System;
    using System.Windows;
    using System.Windows.Interop;
    
    
    namespace WpfListener
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
            {
                HwndSource source = HwndSource.FromHwnd(new WindowInteropHelper(this).Handle);
                source.AddHook(WndProc);
            }
    
            private static IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
            {
    
                if (msg == RF_TESTMESSAGE)
                {
                    MessageBox.Show("I receive a msg here a I can call the method");
                    handled = true;
                }
                return IntPtr.Zero;
            }
    
            private const int RF_TESTMESSAGE = 0xA123;
        }
    }
