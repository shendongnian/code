    modelBuilder.Entity<GuestSeat>()
                .HasKey(gs => new {gs.GuestID,gs.SeatID})
                .ToTable("GuestSeats");
    modelBuilder.Entity<GuestSeat>()
                .HasRequired(g=>g.Guest)
                .WithMany(g=>g.Seats)
                .HasForeignKey(gs =>gs.GuestID)
                .DeleteOnCascade(false);
    modelBuilder.Entity<GuestSeat>()
                .HasRequired(s=>s.Seat)
                .WithMany(s=>s.Guests)
                .HasForeignKey(gs =>gs.SeatID)
                .DeleteOnCascade(false);
