    void initExcel()
        {
            excel = new Microsoft.Office.Interop.Excel.Application();
            wb = excel.Workbooks.Add();
        }
    void AddToExcel(DataTable dt)
        {
            try
            {
                if (firstRun)
                {
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                }
                else
                {
                    ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets.Add();
                }
                for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                {
                    ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                }
                for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                {  
                    ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value =
                    dt.Rows[Idx].ItemArray;
                }
                if (lastRun)
                {
                    excel.Visible = true;
                    wb.Activate();
                }
                firstRun = false;
            }
            catch (COMException ex)
            {
                MessageBox.Show("Error accessing Excel: " + ex.ToString());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.ToString());
            }
        }
