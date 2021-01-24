    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Excel.Application xlApp;
            Excel.Workbook wb;
            Excel.Worksheet ws;
            xlApp = new Excel.Application();
            xlApp.Visible = false;
            xlApp.ScreenUpdating = false;
            wb = xlApp.Workbooks.Open(@"Desired Path of workbook\Copy of BigSpreadsheet.xlsx");
            ws = wb.Sheets["Sheet1"];
            //string rng = ws.get_Range("A1").Value;
            MessageBox.Show(ws.get_Range("A1").Value);
            Marshal.FinalReleaseComObject(ws);
            wb.Close();
            Marshal.FinalReleaseComObject(wb);
            xlApp.Quit();
            Marshal.FinalReleaseComObject(xlApp);
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }
    }
