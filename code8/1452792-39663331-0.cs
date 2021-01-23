    public void update_Release_Status(Status recordModified)
    {
    
        //Get the original record and update with the modified values.
        Status recordOriginal = db3.Status .First(i => i.ID == recordModified.ID);
        recordOriginal = recordModified;
        db3.SaveChanges();
    
    }
