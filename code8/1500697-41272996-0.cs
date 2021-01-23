    public abstract class DtoBase
    {
        [Key]
        public Guid ID { get; protected set; }
    }
    public class PersonDto : DtoBase
    {
        [InverseProperty("Person")]
        public ProspectDto Prospect { get; set; }
    }
    public class ProspectDto : DtoBase
    {
        [ForeignKey("ID")]           // "magic" is here
        public PersonDto Person { get; set; } = new PersonDto();
    }
