    using (var context = new MyDbContext())
    {
         Venue venue = context.Venues.Find(id);
         //If list is null, initlise it
         if (venue.MailingList == null)
         {
              venue.MailingList = new List<string>();
         }
    
         venue.MailingList.Add(email);
    
         context.SaveChanges();
    }
    
