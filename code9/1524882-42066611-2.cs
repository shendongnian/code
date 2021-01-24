     BindingList<Invoice> invoices = new Invoice.Read(null);
     invoices.ListChanged += Invoice_ListChanged;
    
     private void Test_ListChanged(object sender, ListChangedEventArgs e)
     {
        if (e.ListChangedType == ListChangedType.ItemChanged)
        {
           //Calculate Amount and populate to TextBox (invoices is your DataSource)
           textBoxSum.Text = invoices.Sum(invoice => invoice.Amount);
        }
     }
