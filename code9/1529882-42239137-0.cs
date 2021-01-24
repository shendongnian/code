        [STAThread]
        static void Main(string[] args)
        {
            Excel.Application xl = null;
            try {
                xl = new Excel.Application();
                xl.ScreenUpdating = false;
                xl.Visible = false;
                xl.UserControl = false;
                var wb = xl.Workbooks.Open(SOURCE_PATH);
                var ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Sheets.Item["850_Template"];
                StringBuilder sb = new StringBuilder();
                //int row = 3;
                // var a1 = ws.Range["A1", Missing.Value];
                using (SqlConnection cn = new SqlConnection(CN_STR)) {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand(SQL, cn)) {
                        cmd.CommandType = CommandType.Text;
                        using (SqlDataReader dr = cmd.ExecuteReader()) {
                            while (dr.Read())
                            {
                                sb.AppendFormat("{0}\t{1}\t{2}\t{3}\t{4}\t{5}\t{6}\t{7}\r\n",
                                    (string)dr["OrgName"],
                                    (string)dr["WholeSalerAccountDivisionCode"],
                                    (string)dr["File_Process_Name"],
                                    (string)dr["Pur_Ord_Num_BEG03"],
                                    (long)dr["File_Process_ID"],
                                    (string)dr["CECode"],
                                    (string)dr["CEName"],
                                    (DateTime)dr["Modified_Date"]
                                    );
                                //a1.Offset[row, 0].Value = (string)dr["OrgName"];
                                //a1.Offset[row, 1].Value = (string)dr["WholeSalerAccountDivisionCode"];
                                //a1.Offset[row, 2].Value = (string)dr["File_Process_Name"];
                                //a1.Offset[row, 3].Value = (string)dr["Pur_Ord_Num_BEG03"];
                                //a1.Offset[row, 4].Value = (long)dr["File_Process_ID"];
                                //a1.Offset[row, 5].Value = (string)dr["CECode"];
                                //a1.Offset[row, 6].Value = (string)dr["CEName"];
                                //a1.Offset[row, 7].Value = (DateTime)dr["Modified_Date"];
                                //row++;
                            }
                        }
                    }
                    cn.Close();
                }
                Clipboard.SetText(sb.ToString(),
                    TextDataFormat.Text);
                var rng = ws.Range["A3", Missing.Value];
                rng.Select();
                ws.Paste(rng, Missing.Value);
                Clipboard.Clear();
                wb.Save();
                wb.Close();
                xl.Quit();
            } catch (Exception ex) {
                Console.WriteLine(ex.Message);
                if (xl != null) {
                    xl.ScreenUpdating = true;
                    xl.Visible = true;
                    xl.UserControl = true;
                }
            }
        }
