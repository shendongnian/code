     //This will be what you named your entities from your .edmx
     public static myEntities _db = new myEntities ();
    (Auto-Generated Class via .edmx)
    EF_Class_Name newDbEntry= new EF_Class_Name();
    newDbEntry.Stock = int.Parse(txtStock.Text);
    newDbEntry.Name = txtName.Text;
    newDbEntry.Category = dropdown.SelectedValue;
    _db.EF_Class_Name.Add(newDbEntry);
    
    _db.SaveChanges();
