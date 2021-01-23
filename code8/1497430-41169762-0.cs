    public class ApplicationRole : IdentityRole<Guid>, IBaseEntity<Guid>
    {
        public DateTime CreatedAt {get; set;}
        public Nullable<DateTime> UpdatedAt {get; set;}
        public Nullable<DateTime> DeletedAt {get; set;}      
    }
