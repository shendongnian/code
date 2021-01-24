    builder.Entity<Message>()
        .HasOne(x => x.MessageForUser)
        .WithMany(x => x.UserMessages)
        .HasForeignKey(x => x.MessageForUserId)
        .OnDelete(DeleteBehavior.Cascade);
    builder.Entity<Message>()
        .HasOne(x => x.MessageFromUser)
        .WithMany(x => x.SentMessages)
        .HasForeignKey(x => x.MessageFromUserId)
        .OnDelete(DeleteBehavior.Cascade);
