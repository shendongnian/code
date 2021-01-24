    public class FunctionsCreateDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<string> RoleLibelles { get; set; }
    }
