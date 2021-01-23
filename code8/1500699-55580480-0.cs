    // Model classes:
    public abstract class DtoBase
    {
        public Guid ID { get; protected set; }
    }
    public class PersonDto : DtoBase
    {
        public ProspectDto Prospect { get; set; }
    }
    public class ProspectDto : DtoBase
    {
        public PersonDto Person { get; set; } = new PersonDto();
    }
    -------------------------------------------------------------------
    // DbContext's OnModelCreating override:
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasOne(p => p.Person).WithOne().HasForeignKey<ProspectDto>(p => p.ID);
    }
