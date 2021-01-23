	// Yes, this is a navigation property
	public Organizations OrgId { get; set; } 
	
	// This is also navigation property
	public virtual ICollection<Organizations> Organizations { get; set; }
