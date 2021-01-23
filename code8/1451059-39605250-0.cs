    protected void Button4_Click(object sender, EventArgs e)
    {
        var newRegion = new EFDataStore.Region() <==== Need full namespace.
        {
            RegionID = 5000,
            RegionDescription = TextBox1.Text
    
        };
    
        db.Regions.Add(newRegion);
        db.SaveChanges();
    
    }
