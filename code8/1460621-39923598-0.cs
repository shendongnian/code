    protected void BtnRun_Click(object sender, EventArgs e)
    {
       radGrid.Rebind();
    }
    // Make sure you attach RadGrid_NeedDataSource event to grid inside markup.
    protected void RadGrid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
    {
       var dt = new DataTable();
       Sprocs._pDash_NewBusiness(BeginDate.SelectedDate.Value, 
          EndDate.SelectedDate.Value, dt);
           
       radGrid.DataSource = dt;
    }
