    protected void ddl1_SelectedIndexChanged(object sender, EventArgs e)
    {
      if (ddl1.SelectedItem.Value == "1")
      {
        Get1();
      }
      else if (ddl1.SelectedItem.Value == "2")
      {
        Get2();
      }
    }
