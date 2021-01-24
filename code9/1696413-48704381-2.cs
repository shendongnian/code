	public abstract class MyEntityTypeConfiguration<T> : EntityTypeConfiguration<T>, IEntConfig
             where T : class {
		public void MapEntity(ModelBuilder builder) => Map(builder.Entity<T>());
	}
	public class BlockConfig : MyEntityTypeConfiguration<Block> {
		public override void Map(EntityTypeBuilder<Block> builder) {
            // Do stuff
        } 
	}
