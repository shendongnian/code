    public class EntityTypeForViewMap : EntityTypeConfiguration<EntityTypeForView>
    {
        public EntityTypeForViewMap()
        {
            this.ToTable("Name_Of_View"); // actual name of the view         
        }
    }
