    protected override void Seed(YourContext context)
    {
        var entities=context.Revisions.Where(r=>!r.IsReleased)
        foreach(var e in entities)
        {
          e.IsReleased=true;
         //context.Entry(e).State = EntityState.Modified; If you have disabled change tracking then add this line
        }
        context.SaveChanges();
    }
