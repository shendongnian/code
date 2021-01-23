            Excel.Application xlApp = (Excel.Application)System.Runtime.InteropServices.Marshal.GetActiveObject("Excel.Application");
            Excel.Range myRange;
            myRange = xlApp.ActiveSheet.UsedRange;
            DataTable dtProductRowsFromExcel = new DataTable(); //to save all productrows form excel offer.
            
            dtProductRowsFromExcel.Columns.Add("Code", typeof(String)); //column 1          Excel B
            dtProductRowsFromExcel.Columns.Add("Amount", typeof(String)); //column 2        Excel C
            dtProductRowsFromExcel.Columns.Add("Unit", typeof(String)); //column 3          Excel D
            dtProductRowsFromExcel.Columns.Add("ValutaUnit", typeof(String)); //column 4    Excel E
            dtProductRowsFromExcel.Columns.Add("PriceUnit", typeof(String)); //column 5     Excel F
            dtProductRowsFromExcel.Columns.Add("ValutaTotal", typeof(String)); //column 6   Excel G
            dtProductRowsFromExcel.Columns.Add("PriceTotal", typeof(String)); //column 7    Excel H
            try
            {
                Excel.Range currentFind = null;
                Excel.Range firstFind = null;
                var missing = Missing.Value;
                Excel.Range RangeWithValutaSigns = xlApp.ActiveSheet.Range("g1", "g500");
                currentFind = RangeWithValutaSigns.Find(lblValutaTeken.Text, missing,
                    Excel.XlFindLookIn.xlValues, Excel.XlLookAt.xlPart,
                    Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlNext, false,
                    missing, missing);
                while (currentFind != null)
                {
                  
                    if (firstFind == null)
                    {
                        firstFind = currentFind;
                    }
                    else if (currentFind.get_Address(Excel.XlReferenceStyle.xlA1)
                          == firstFind.get_Address(Excel.XlReferenceStyle.xlA1))
                    {
                        break;
                    }
                    Console.WriteLine("~~~~ currentFind.Row = " + currentFind.Row);
                    string B = currentFind.Offset[0, -5].Value2.ToString();
                    string C = (currentFind.Offset[0, -4].Value2 != null) ? currentFind.Offset[0, -4].Value2.ToString() : "";
                    string D = (currentFind.Offset[0, -3].Value2 != null) ? currentFind.Offset[0, -3].Value2.ToString() : "";
                    string E = (currentFind.Offset[0, -2].Value2 != null) ? currentFind.Offset[0, -2].Value2.ToString() : "";
                    string F = (currentFind.Offset[0, -1].Value2 != null) ? currentFind.Offset[0, -1].Value2.ToString() : "";
                    string G = currentFind.Value2.ToString();
                    string H = (currentFind.Offset[0, 1].Value2 != null) ? currentFind.Offset[0, 1].Value2.ToString() : "";
                    dtProductRowsFromExcel.Rows.Add(B, C, D, E, F, G, H);
                    currentFind = RangeWithValutaSigns.FindNext(currentFind);
                    }
                // to check datatable in output window use:
                foreach (DataRow dataRow in dtProductRowsFromExcel.Rows)
                {
                    foreach (var item in dataRow.ItemArray)
                    {
                        Console.WriteLine(item);
                    }
                }
                dataGridView1.ReadOnly = true;
                dataGridView1.RowHeadersVisible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dataGridView1.DataSource = dtProductRowsFromExcel;
                dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableWithoutHeaderText;
                dataGridView1.SelectAll();
                DataObject d = dataGridView1.GetClipboardContent();
                Clipboard.SetDataObject(d);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error message:" + System.Environment.NewLine + ex.Message);
            }
