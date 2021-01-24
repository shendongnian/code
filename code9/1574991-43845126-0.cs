     using (var transaction = _context.Database.BeginTransaction())
     {
          _context.AwsmAppusers.Attach(User);
          _context.Remove(User);
          _context.SaveChanges(); 
         transaction.Commit();
     }
