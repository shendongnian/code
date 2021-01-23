      private void btnNext_Click(object sender, System.EventArgs e)
      {
       System.Windows.Forms.CurrencyManager bc;
    
       bc = (CurrencyManager) this.BindingContext[this.dsEmployeeList1, "Employees"];
       bc.Position += 1;
       UpdateDisplay();
      }
