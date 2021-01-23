    using (var context = new SampleDBEntities())
    {
           PlaceInfo placeToUpdate = context.PlaceInfoes.Find(Convert.ToInt32(txtName.Value));
           placeToUpdate.Name = txtName.Text;
           placeToUpdate.Address = txtAddress.Text;
           placeToUpdate.Geolocation = DbGeography.FromText("POINT( "+hdnLocation.Value+")");
           
           context.Entry(placeToUpdate).State = EntityState.Modified;
           context.SaveChanges();
    }
