        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<RelationshipGuestLink>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<RelationshipGuestLink>()
                    .HasRequired(x => x.Guest).WithMany(x => x.RelationshipLinks).HasForeignKey(x => x.Guest);
            modelBuilder.Entity<RelationshipGuestLink>()
                .HasRequired(x => x.Relationship).WithRequiredDependent();
        }
        public class RelationshipGuestLink
        {
            public Guid Id { get; set; }
            public Guid GuestId { get; set; }
            public Guid RelationshipId { get; set; }
            public Guid RelatedGuestId { get; set; }
            public Guest Guest { get; set; }
            public Relationship Relationship { get; set; }
            public Guest RelatedGuest { get; set; }
        }
