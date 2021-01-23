    public abstract class Entity
    {
        public string Id { get; set; }
        public DateTime Created { get; set; }
        public string CreatedBy { get; set; }
        public DateTime Modified { get; set; }
        public string ModifiedBy { get; set; }
    
        public Entity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Created = DateTime.UtcNow;
            this.Modified = this.Created;
        }
        public Entity(string createdBy, string modifiedBy) : this()
        {
            this.CreatedBy = createdBy;
            this.ModifiedBy = modifiedBy;
        }
    }
    
    public class Department : Entity
    {
        public string Name { get; set; }
    
        public virtual ICollection<Student> Students { get; set; }
    }
    
    public class Student : Entity
    {
        public string Name { get; set; }
        public string Phone { get; set; }
    
        public string DepartmentId { get; set; }
        public virtual Department Department { get; set; }
    }
