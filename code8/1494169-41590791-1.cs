    using System.Printing;          // Add reference to System.Printing
    using System.Printing.Interop;  // Add reference to ReachFramework
    using System.Diagnostics;
    ....
        public MainWindow() {
            InitializeComponent();
            // Assume default printer
            var queue = new LocalPrintServer().DefaultPrintQueue;
            var cvt = new PrintTicketConverter(queue.Name, PrintTicketConverter.MaxPrintSchemaVersion);
            // Display dialog, don't make changes
            var dlg = new PrintDialog();
            dlg.ShowDialog();
            var devmode1 = cvt.ConvertPrintTicketToDevMode(dlg.PrintTicket, BaseDevModeType.UserDefault);
            // Consistency check
            var dmSize = BitConverter.ToInt16(devmode1, 68);
            var dmDriverExtra = BitConverter.ToInt16(devmode1, 70);
            Debug.Assert(dmSize == 220);
            Debug.Assert(dmDriverExtra > 0);
            Debug.Assert(dmSize + dmDriverExtra == devmode1.Length);
            // Display dialog again, do make the change
            dlg.ShowDialog();
            var devmode2 = cvt.ConvertPrintTicketToDevMode(dlg.PrintTicket, BaseDevModeType.UserDefault);
            var len = Math.Min(devmode1.Length, devmode2.Length);
            for (int ix = 0; ix < len; ++ix) {
                if (devmode1[ix] != devmode2[ix]) {
                    Debug.Print("Change at {0} from {1} to {2}", ix, devmode1[ix], devmode2[ix]);
                }
            }
            // Tinker with the DEVMODE...
            var magic = dmSize + 0;   // Change this
            Debug.Assert(magic < dmSize + dmDriverExtra);
            devmode1[magic] = devmode2[magic];
            dlg.PrintTicket = cvt.ConvertDevModeToPrintTicket(devmode1);
            // Verify that the setting changed!
            dlg.ShowDialog();
        }
    }
