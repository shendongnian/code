    public class CreateVm
    {
       [Required]
       public int SelectedUniversity { set;get;}
       [Required]
       public int SelectedFaculty { set;get;}  
       public List<SelectListItem> Universities { set;get;}    
       public List<SelectListItem> Faculties { set;get;}
    
       public CreateVm()
       {
           this.Faculties = new List<SelectListItem>();
           this.Universities = new List<SelectListItem>();
       }  
    }
