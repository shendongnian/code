C#
using Microsoft.Office.Interop.Excel; 
 string getDefaultUserName()
        {
            ExcelApi.Application ap = (ExcelApi.Application)Marshal.GetActiveObject("Excel.Application");
            string userName = null;
            try
            {
                userName = ap.UserName;
            }
            catch (Exception ex)
            { 
            }
            finally
            {
                if (ap != null)
                {
                    Marshal.ReleaseComObject(ap);
                }
            }
            return userName;
        }
