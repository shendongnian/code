    //Data Annotations
    public class EmployeeEntity : BaseEntity
    {
        // Denotes the primary key column
        [Key]
        public short Id { get; set; }
        public string Name { get; set; }
        // more fields, probably
    }
    // Fluent API
    public partial class EmployeeMap : EntityTypeConfiguration<EmployeeEntity>
    {
        public EmployeeMap()
        {
            ToTable("employee");
            HasKey(emp => emp.Id);
        }
    }
    
