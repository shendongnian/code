     SQLiteConnection database = DependencyService.Get<ISQLite>().GetConnection();
     database.CreateTable<Announcement>(); 
     var announcement = new Announcement { AnnouncementTitle = Title, AnnouncementDate = Date, AnnouncementText = Message };
     if (text == "Save") {
         if (database.Insert(announcement) != -1) {
             System.Diagnostics.Debug.WriteLine("INSERTED");
         }
    
     }
     else {
        var announcementToUpdate = database.Query<Customer>($"SELECT * FROM Announcement WHERE Id = '{originalId}'").
        // update your 'announcementToUpdate' object with new values here
        if (database.Update(announcementToUpdate) > 0) {
           System.Diagnostics.Debug.WriteLine("UPDATED");
        }
     }
