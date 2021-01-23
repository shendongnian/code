    private void AddProducts()
        {
            foreach (Panel p in pnlReport.Controls.OfType<Panel>())
            {
                if (p.Name == last)
                {
                    globalY = p.Location.Y + 140;
                }
            }
            
            for (DateTime date = dtpSDate.Value; date.Date <= dtpCDate.Value; date = date.AddDays(1))
            {
                pnlReport.Controls.Add(new Label { Text = date.ToString(), Height = 20, Width = 150, Name = date.ToString(), Location = new Point(20, globalY), Font = new Font("Arial", 10, FontStyle.Bold) });
                globalY += 30;
                foreach (DataRowView lstvItem in chkListProducts.CheckedItems)
                {
                    string table = "";
                    string select = "";
                    if (Regex.IsMatch(lstvItem[this.chkListProducts.DisplayMember].ToString(), @"^[a-hA-H]"))
                    {
                        table = "ProductHistoryAH";
                    }
                    else if (Regex.IsMatch(lstvItem[this.chkListProducts.DisplayMember].ToString(), @"^[i-qI-Q]"))
                    {
                        table = "ProductHistoryIQ";
                    }
                    else if (Regex.IsMatch(lstvItem[this.chkListProducts.DisplayMember].ToString(), @"^[r-zR-Z]"))
                    {
                        table = "ProductHistoryRZ";
                    }
                    DataTable ProdTmp1 = new DataTable();
                    string sqlP1 = "SELECT * FROM " + table + " WHERE ProdID = '" + lstvItem[this.chkListProducts.ValueMember] + "' AND ProdHDate = '" + date.ToString(@"yyyy\/MM\/dd") + "'";
                    ProdTmp1 = db.GetDataTable(sqlP1);
                    DataTable ProdTmp2 = new DataTable();
                    string sqlP2 = "SELECT * FROM Product WHERE ProdID = '" + lstvItem[this.chkListProducts.ValueMember] + "'";
                    ProdTmp2 = db.GetDataTable(sqlP2);
                                        
                    if (Side == "Left")
                    {
                        Panel pnltmp = new Panel();
                        pnltmp.Size = new Size(472, 120);
                        pnltmp.Location = new Point(5, globalY);
                        pnltmp.BackColor = Color.Green;
                        pnltmp.Name = ProdTmp2.Rows[0][1].ToString() + count.ToString();
                        //Name
                        Label lblName = new Label();
                        lblName.Text = lstvItem[this.chkListProducts.DisplayMember].ToString();
                        lblName.Location = new Point(5, 5);
                        pnltmp.Controls.Add(lblName);
                        int Location = 0;
                        //Count
                        if (chkPCount.Checked)
                        {
                            Label lblCount = new Label();
                            if(ProdTmp1.Rows.Count>0)
                            {
                                lblCount.Text = "Count: " + ProdTmp1.Rows[0][4].ToString();
                            }
                            else
                            {
                                lblCount.Text = "Count: 0";
                            }                            
                            lblCount.Location = new Point(17, 32);
                            pnltmp.Controls.Add(lblCount);
                        }                                              
                        pnlReport.Controls.Add(pnltmp);
                        Side = "Right";
                    }
                    else if(Side == "Right")
                    {
                        Panel pnltmp = new Panel();
                        pnltmp.Size = new Size(472, 120);
                        pnltmp.Location = new Point(487, globalY);
                        pnltmp.BackColor = Color.Red;
                        pnltmp.Name = ProdTmp2.Rows[0][1].ToString() + count.ToString();
                        //Name
                        Label lblName = new Label();
                        lblName.Text = lstvItem[this.chkListProducts.DisplayMember].ToString();
                        lblName.Location = new Point(5, 5);
                        pnltmp.Controls.Add(lblName);
                        //Count
                        if (chkPCount.Checked)
                        {
                            Label lblCount = new Label();
                            if (ProdTmp1.Rows.Count > 0)
                            {
                                lblCount.Text = "Count: " + ProdTmp1.Rows[0][4].ToString();
                            }
                            else
                            {
                                lblCount.Text = "Count: 0";
                            }
                            lblCount.Location = new Point(17, 32);
                            pnltmp.Controls.Add(lblCount);
                        }                        
                        pnlReport.Controls.Add(pnltmp);
                        Side = "Left";
                        globalY += 140;                                         
                    }
                    last = ProdTmp2.Rows[0][1].ToString() + count.ToString();
                }
                if (Side == "Right")
                {
                    Side = "Left";
                    globalY += 140;
                }          
            }
            count++;
        }
