    private BindingSource bs = new BindingSource();
    private BindingList<ObatsEntity> initialObats = new BindingList<ObatsEntity>();
    private void ucObat_Load(object sender, EventArgs e)
    {
        db = new DbSIMP3Entities();
        initialObats = new BindingList<ObatsEntity>( db.tbObats.ToList() );
        bs.DataSource = initialObats;
        dataGridView.DataSource = bs;
    }
    private void txtSearch_Click(object sender, EventArgs e)
    {
        var filteredObats = new BindingList<ObatsEntity>( initialObats.Where( o => o.NmObat = txtSearch.Text ).ToList() );
        bs.DataSource = filteredObats;
        bs.ResetBindings();
    }
