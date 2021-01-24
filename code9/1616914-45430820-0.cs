    public static SaveChangesTimed(this YourDbContext _context, ITiming timed) {
       timed.CreatedAt = DateTime.Now;
       timed.UpdatedAt = Datetime.Now;
       _context.SaveChanges();
    }
