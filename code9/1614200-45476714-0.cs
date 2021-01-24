      using Excel = Microsoft.Office.Interop.Excel;
      private void btnEX_Click(object sender, RoutedEventArgs e)
        {
           
            Excel.Application excel = null;
            Excel.Workbook wb = null;
            object missing = Type.Missing;
            Excel.Worksheet ws = null;
            Excel.Range rng = null;
            try
            {
                excel = new Microsoft.Office.Interop.Excel.Application();
                wb = excel.Workbooks.Add();
                ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.ActiveSheet;
                DataView view = (DataView)grdKQ_TASK.ItemsSource;
                DataTable dt = DataViewAsDataTable(view);
                for (int Idx = 0; Idx < dt.Columns.Count; Idx++)
                {
                    ws.Range["A1"].Offset[0, Idx].Value = dt.Columns[Idx].ColumnName;
                }
                for (int Idx = 0; Idx < dt.Rows.Count; Idx++)
                {  
                    ws.Range["A2"].Offset[Idx].Resize[1, dt.Columns.Count].Value = dt.Rows[Idx].ItemArray;
                }
                excel.Visible = true;
                wb.Activate();
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
        public static DataTable DataViewAsDataTable(DataView dv)
        {
            DataTable dt = dv.Table.Clone();
            foreach (DataRowView drv in dv)
                dt.ImportRow(drv.Row);
            return dt;
        }
