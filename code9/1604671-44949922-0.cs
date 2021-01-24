    private void brandBookBindingNavigatorSaveItem_Click(object sender, EventArgs e)
    {
      this.Validate();
      var changes = dataSet1.GetChanges();
      if(changes!=null && changes.Tables["BrandBook"].Rows.Count>0)
      {
        foreach(row in changes.Tables["BrandBook"].Rows)
        {
          row["ts_last_edit"] = DateTime.Now;
        }
      }
      dataSet1.Merge(changes, false,System.Data.MissingSchemaAction.Add);
      this.brandBookBindingSource.EndEdit();
      this.tableAdapterManager.UpdateAll(this.dataSet1);
    }
