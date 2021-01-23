    public class Module
    {
    [Key]
    public int id { get; set; }
    [Required]
    [StringLength(100)]
    [Column(TypeName = "varchar")]
    public string ModuleName { get; set; }
    }
    public class ModuleViewModel
    {
    public int id { get; set; }
    [Required]
    [StringLength(30)]
    [Display(Name="Module ID")]
    public string ModuleID { get; set; }
    [Required]
    [StringLength(100)]
    [Display(Name="Module Name")]
    public string ModuleName { get; set; }
    //To populate dropdownlist 
    public List<SelectListItem> ModuleLevelList { get; set; }
    }
