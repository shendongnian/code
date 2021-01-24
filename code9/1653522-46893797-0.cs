       static void CreateSupplier(int id)
        {
            var contactId = id; //the id being passed in would have been collected from a list of Customers, as we want Fred Flintstone it would have been set to 2
            var date = DateTime.UtcNow;
            using (var context = new ContactsContext())
            {
                context.Database.Log = Console.Write; //purely for logging
                context.Database.ExecuteSqlCommand(
                   "INSERT INTO Contacts.Suppliers(Id, DateStarted) VALUES({0}, {1})", contactId, date);
                context.SaveChanges();
            }
        }
