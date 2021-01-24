     // This will be what you named your entities from your .edmx
     // This object sets up the connection to your entities 
     public static myEntities _db = new myEntities ();
    (Auto-Generated Class via .edmx)
    // When you add an .edmx file (database diagram for EF)
    // There is an auto-generated class you are able to use - 
    // We are setting this up below.
    EF_Class_Name newDbEntry= new EF_Class_Name();
    // You can access any property of the class just like any other object
    // property.
    newDbEntry.Stock = int.Parse(txtStock.Text);
    newDbEntry.Name = txtName.Text;
    newDbEntry.Category = dropdown.SelectedValue;
    // Add your new data (essentially an insert)
    _db.EF_Class_Name.Add(newDbEntry);
    
    // Commit the changes
    _db.SaveChanges();
