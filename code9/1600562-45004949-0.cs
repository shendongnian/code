        public class ModelConfiguration
        {
            private static void ConfigureGridDataCollectionEntity(DbModelBuilder modelBuilder)
            {
                // Student
                modelBuilder.Entity<Student>()
                    .HasMany(p => p.Friends)
                    .WithMany()
                    .Map(cs =>
                    {
                        cs.MapLeftKey("StudentId");
                        cs.MapRightKey("FriendsId");
                        cs.ToTable("StudentFriend");
                    });
            }
        }
