    private void Form1_Load(object sender, EventArgs e)
    {
      using (this.inventoryTableAdapter.Fill(this._Wizard_Data_2016_10_17DataSet.Inventory); = new _Wizard_Data_2016_10_17DataSet())
      {
         productBindingSource.DataSource = DB.Products.ToList();
      }
    }
