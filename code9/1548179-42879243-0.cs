    if (venue.MailingList == null)
    {
              venue.MailingList = new List<string>();
    }
    venue.MailingList.Add(email);
    venue.MailingList.Entry(email).State = EntityState.Added; // you need to add this statement
    db.SaveChanges();
