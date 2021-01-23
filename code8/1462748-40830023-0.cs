    private void PrintLabelVal()
            {
                string str = Properties.Settings.Default.con;
                SqlConnection Conn = new SqlConnection(str);
    
    
                string query = " SELECT TempLotUpdate.Quantity,Item.BinLocation,Item.ItemLookupCode," +
                                " Item.ExtendedDescription,Item.LotNumber," +
                                " Item.ExpiryDate " +
                                " FROM TempLotUpdate" +
                                 " INNER JOIN Item ON TempLotUpdate.ItemId = Item.ID" +
                             
                                " WHERE TempLotUpdate.PONumber = '" + Globals.s_PON + "'; ";
                int cnt = 0;
                int var = 0;
                SqlCommand cmd = new SqlCommand(query, Conn);
                try
                {
                    Conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    DataTable dt = new DataTable();
                    da.Fill(dt);
    
                    for (var i = 0; i < dt.Rows.Count; i++)
                    {
                        cnt = Convert.ToInt32(dt.Rows[i][0]);
                        var = Convert.ToInt32(dt.Rows[i][4]);
                        for (var j = 0; j < cnt; j++)
                        {
                            var = Convert.ToInt32(dt.Rows[i][4]);
                            print(var); // Passing Lot ID
                        }
                    }
                 }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
    
            private void print(int obj)
            {
                FillData(obj);
                ItemPrint();
                this.Close();
            }
            void FillData(int ID)
            {
                string str = Properties.Settings.Default.con;
                using (SqlConnection conn = new SqlConnection(str))
                {
                    try
                    {
                        string query = "SELECT ItemLookupCode BarCode,Description,ExpiryDate,BinLocation,Price " +
                                       " FROM Item where ID = " + ID + ";";
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(query, conn);
                        SqlDataReader dtr = cmd.ExecuteReader();
                        if (dtr.Read())
                        {
                          
                            barCode = dtr[0].ToString();
                            s_desc = dtr[1].ToString();
                            s_date = dtr[2].ToString();
                            s_BinLoc = dtr[3].ToString();
                            s_Price = dtr[4].ToString();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
    
            private void ItemPrint()
            {
                PrintDialog printdg = new PrintDialog();
                if (printdg.ShowDialog() == DialogResult.OK)
                {
                    PrintDocument pd = new PrintDocument();
                    pd.PrinterSettings = printdg.PrinterSettings;
                    pd.PrintPage += PrintPage;
                    pd.Print();
                    pd.Dispose();
                }
            }
            private void PrintPage(object o, PrintPageEventArgs e)
            {
                string _desc = s_desc;
                var _g = e.Graphics;
                _g.DrawString(_desc, new Font("Arial Black", 7), Brushes.Black, 5, 8);
    
                string _bCode = "*"+barCode+"*";
                var _f = e.Graphics;
                _f.DrawString(_bCode, new Font("IDAHC39M Code 39 Barcode", 8), Brushes.Black, 4, 25);
    
                string _BinLoc = s_BinLoc;
                var _i = e.Graphics;
                _i.DrawString(_BinLoc, new Font("Arial Narrow", 7), Brushes.Black, 5, 75);
                
                string _date = "Exp: " + s_date.Substring(0, 10);
                var _h = e.Graphics;         
                _h.DrawString(_date, new Font("Arial Narrow", 7), Brushes.Black, 45, 75);
    
                string _Price = s_Price;
                var _j = e.Graphics;         
                _j.DrawString(_Price, new Font("Arial Narrow", 7), Brushes.Black, 120, 75);
            }
