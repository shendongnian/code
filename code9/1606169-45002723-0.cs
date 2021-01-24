    public class ExcelProcess
    {
        [DllImport("user32.dll")]
        static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
    
        public static System.Diagnostics.Process GetExcelProcess(oExcel.Application excelApp)
        {
            int id;
            GetWindowThreadProcessId(excelApp.Hwnd, out id);
            return System.Diagnostics.Process.GetProcessById(id);
        }
    }
