      private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
          
            int id = e.RowHandle;
            DataRow row = gridView1.GetDataRow(id);
            int ddl1 = Convert.ToInt32(gridView1.GetRowCellValue(id, "invoiceId").ToString());
            if (e.Column.Name=="ActionUpdate")
            {
                invoiceSummary Obj = new invoiceSummary
                   {
                       CustomerName = gridView1.GetRowCellValue(id, "customerName").ToString(),
                       InvoiceID = Convert.ToInt32(gridView1.GetRowCellValue(id,"invoiceId").ToString()),
                       IssueDate = gridView1.GetRowCellValue(id,"issue_date").ToString(),
                       DueDate = gridView1.GetRowCellValue(id,"due_date").ToString(),
                       Status = gridView1.GetRowCellValue(id,"Status").ToString(),
                       PrivateNote = gridView1.GetRowCellValue(id,"privateNotes").ToString(),
                       PadiAmount = Convert.ToDouble(gridView1.GetRowCellValue(id,"Amount_Paid").ToString()),
                       Balance = Convert.ToDouble(gridView1.GetRowCellValue(id,"Balance").ToString()),
                       PaymentType = gridView1.GetRowCellValue(id,"paymentType").ToString(),
                       DateOfPayment = gridView1.GetRowCellValue(id,"DateOfPayment").ToString(),
                       TotalDiscount = Convert.ToDouble(gridView1.GetRowCellValue(id,"TotalDiscount").ToString()),
                       PackagingAmount = Convert.ToDouble(gridView1.GetRowCellValue(id,"PackagingAmount").ToString()),
                       CustomerNote = gridView1.GetRowCellValue(id,"CustomerNote").ToString(),
                       TaxTotalAmount = Convert.ToDouble(gridView1.GetRowCellValue(id,"Tax_Amount").ToString()),
                       Valuedata = Convert.ToDouble(gridView1.GetRowCellValue(id,"Amount").ToString()),
                       TotalSubAmount = Convert.ToDouble(gridView1.GetRowCellValue(id,"Total_Amount").ToString()),
                   };
                frmAddinvoice fm = new frmAddinvoice(Obj);
                fm.ShowDialog();
                this.Close();
                GetInvoiceSummaryData();
            }
            else
            {
                MessageBox.Show("");
            }
            
        }
