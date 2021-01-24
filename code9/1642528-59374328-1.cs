    modelBuilder.Entity<UserLike>(entity =>
    {
        entity.HasOne(x => x.User)
        .WithMany(x => x.UserLikes)
        .OnDelete(DeleteBehavior.ClientCascade);
    }
