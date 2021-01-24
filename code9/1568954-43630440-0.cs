    private IQueryable<User> _query;
    private void btnFindName_Click(object sender, EventArgs e)
    {
        _query = db.Users.AsQueryable();
        _query = _query.Where(x => x.name == txtName);
        userBindingSource.DataSource = _query.ToList();
    }
    
    private void sortToolStripMenuItem_Click(object sender, EventArgs e)
    {
        userBindingSource.DataSource = _query.OrderBy(x => x.name).ToList();
    }  
