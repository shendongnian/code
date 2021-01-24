    public override void OnModelCreating(...)
    {
        modelBuilder.Entity<Position>()
             // a position has zero or more Employees via property Employees
             .HasMany(position => position.Employees)
             // every Employee has exactly one Position
             .WithRequired(employee => employee.Position)
             // using foreign key Position_id
             .HasForeignKey(employee => employee.Position_Id);
    }
