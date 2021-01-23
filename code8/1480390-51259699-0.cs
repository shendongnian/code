            cmdSave.PerformClick();
            string sqlCmd = "Update tbl_Ledger " +
                            " Set RSelected=0";
            DataAccess.ExecuteSQL(sqlCmd);
            string sqlCmd2 = "Update tbl_Ledger " +
                             " Set RSelected=1 " +
                             " where supplierid=" + this.txtSupplierID.Text + 
                             " AND  xRecDate BETWEEN '" + DateFrom.Text + "' AND    '" + DateTo.Text + "'";
            DataAccess.ExecuteSQL(sqlCmd2);
            Ledger.LedgerRep go = new Ledger.LedgerRep();
            go.supplierID = this.txtSupplierID.Text;
            go.RSelected = "1";
            go.Show();
