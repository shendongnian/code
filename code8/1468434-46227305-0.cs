    public class Department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    
        public string Name { get; set; }
    
        public int? ParentId { get; set; }
    
        public virtual Department Parent { get; set; }
    
        public virtual ICollection<Department> Children { get; set; }
    	
    	private IList<Department> allParentsList = new List<Department>();
    	
    	public IEnumerable<Department> AllParents()
        {
            var parent = Parent;
            while (!(parent is null))
            {
                allParentsList.Add(parent);
                parent = parent.Parent;
            }
            return allParentsList;
        }
    }
