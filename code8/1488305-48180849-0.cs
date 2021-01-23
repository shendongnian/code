    public class Text
    {
        public long Id { get; set; }
        public int UserId { get; set; }// add a foreign key that could point to User.Id
        public string Body { get; set; }//you cannot have a string property called "Text".
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
                table.HasOne(x => x.User)
                .WithMany(x => x.Texts)
                .HasForeignKey(x => x.UserId)
                .HasPrincipalKey(x => x.Id)//<<== here is core code to let foreign key userId point to User.Id.
                .OnDelete(DeleteBehavior.Cascade);
            });
