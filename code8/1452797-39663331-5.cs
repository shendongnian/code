    public void update_Release_Status(Status recordModified)
    {
    
        Status recordOriginal = db3.Status.First(i => i.ID == recordModified.ID);
        recordOriginal.Name = recordModified.Name;//here you have to do the mapping
        recordOriginal.Age=recordModified.Age; //just used fake property names :)
        db3.SaveChanges();
    
    }
