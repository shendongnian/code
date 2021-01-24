    private class GIS
    {
        public int AccountNo { get; set; }
        public string AccountName { get; set; }
    }
    var missing = xl.Where(x => !ac.Any(a => a.AccountNo == x.AccountNo));
    var bS = new BindingSource();
    bS.DataSource = missing;
    dataGridView1.DataSource = bS;
 
