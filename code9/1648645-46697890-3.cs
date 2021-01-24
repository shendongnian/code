    public class VehicleModelViewModel
    {
       public List<SelectListItem> Makes { set;get;}
       [Required]
       [Display(Name = "Vehicle Model Name")]
       public string Name { get; set; }
       [Required]
       [Display(Name = "Vehicle Make Id")]  
       public int VehicleMakeId { get; set; } 
    }
