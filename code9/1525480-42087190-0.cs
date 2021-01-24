    public class FunctionsDTO
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public virtual ICollection<RolesDTO> Roles { get; set; }
    }
