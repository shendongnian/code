    public class ActionConfiguration : EntityTypeConfiguration<Action>
    {
      public ActionConfiguration()
      {
        ToTable("Actions");
        HasKey(x => x.ActionId);
    
        HasRequired(x => x.GrantedTo)
          .WithMany()
          .Map(x => x.MapKey("GrantedToId"))
          .WillCascadeOnDelete(false);
      }
    }
