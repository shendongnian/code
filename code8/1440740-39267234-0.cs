       [System.Runtime.InteropServices.DllImport("user32.dll")]
            static extern int GetWindowThreadProcessId(int hWnd, out int lpdwProcessId);
    
            public static Process GetExcelProcess(Microsoft.Office.Interop.Excel.Application excelApp)
            {
                int id;
                GetWindowThreadProcessId(excelApp.Hwnd, out id);
                return Process.GetProcessById(id);
            }
