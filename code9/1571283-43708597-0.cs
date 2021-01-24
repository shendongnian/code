     public class Context: DbContext{
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
             ...
             entity.HasOne(d => d.EntityParent)
               .WithMany(p => p.EntityCHild)
              .HasForeignKey(d => d.IDEntityParent)
              .OnDelete(ShouldRestrict)
              .HasConstraintName("FK_Name");
             ...
        }
        protected virtual DeleteBehavior ShouldRestrict{
            get{
                return DeleteBehavior.restrict;
            }
        }
     }
     public class UnrestrictedContext: Context{
        protected override DeleteBehavior ShouldRestrict{
            get{
                // change...
                return DeleteBehavior.....;
            }
        }
     }
