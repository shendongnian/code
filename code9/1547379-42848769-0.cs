    public class Role
    {
        public Role() 
        {
            this.Premission = new HashSet<Premission>();
        }
    
        public int RoleId { get; set; }
        public string RoleName { get; set; }
    
        public virtual ICollection<Premission> Premissions { get; set; }
    }
            
    public class Premission
    {
        public Premission()
        {
            this.Role = new HashSet<Role>();
        }
    
        public int PremissionId { get; set; }
        public string PremissionName { get; set; }
    
        public virtual ICollection<Role> Roles{ get; set; }
    }
