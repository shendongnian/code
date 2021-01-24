    private void YourForm_Load(object sender, EventArgs e)
            {           
                                var uc = new CustomControl();
                    foreach (var detail in CheckDetails)
                        {                       
                           
                                var uc = new CustomControl();
    
                                uc.lblBankName.Text=detail.BankName;
    			                uc.lblLowerLimit.Text=detail.LLimit;
    			                uc.lblHigherLimit.Text=detail.HLimit;
                                var temp = tbl_BankDtls.RowStyles[tbl_BankDtls.RowCount - 1];
                                tbl_BankDtls.RowCount++;
                                tbl_BankDtls.RowStyles.Add(new RowStyle(SizeType.Absolute, 35));                            
                                tbl_BankDtls.Controls.Add(uc, 0,0);
                                this.Height += 40;
                                this.MinimumSize = new Size(this.Width, this.Height);
                        }
            }
 
