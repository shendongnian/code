    public class Unit
    {
    	public Unit()
    	{
    		SubUnits = new HashSet<SubUnit>();
    	}
    
    	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int UnitId { get; set; }
    	public string Name { get; set; }
    
    	[System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    	public virtual ICollection<SubUnit> SubUnits { get; set; }
    
    	public int UnitInfoId { get; set; }
    
    	[ForeignKey("UnitInfoId")]
    	public virtual UnitInfo UnitInfo { get; set; }
    }
    
    public class SubUnit
    {
    	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int SubUnitId { get; set; }
    	public int UnitId { get; set; }
    	public string Name { get; set; }
    
    	[ForeignKey("UnitId")]
    	public virtual Unit ParentUnit { get; set; }
    
    	public int UnitInfoId { get; set; }
    	[ForeignKey("UnitInfoId")]
    	public UnitInfo UnitInfo { get; set; }
    }
    
    public class UnitInfo
    {
    	[Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    	public int UnitInfoId { get; set; }
    	public string Function { get; set; }
    	public string Location { get; set; }
    }
