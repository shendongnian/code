    public class Text
    {
        public long Id { get; set; }
        public string Body { get; set; }
        public virtual User Owner { get; set; }
    }
    public class User
    {
        public int Id { get; set; }
        public virtual ICollection<Text> Texts { get; set; } = new HashSet<Text>();
    }
    builder.Entity<Text>(table =>
            {
                table.HasKey(x => x.Id);
                // Add the shadow property to the model
                table.Property<int>("UserId");
                table.HasOne(x => x.User)
                .WithMany(x => x.Texts)
                .HasForeignKey("UserId")//<<== Use shadow property
                .HasPrincipalKey(x => x.Id)//<<==point to User.Id.
                .OnDelete(DeleteBehavior.Cascade);
            });
