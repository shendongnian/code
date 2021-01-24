    public class CreateVm
    {
       public List<SelectListItem> Universities { set;get;}
       [Required]
       public int SelectedUniversity { set;get;}
    
       public List<SelectListItem> Faculties { set;get;}
       [Required]
       public int SelectedFaculty { set;get;}  
    
       public CreateVm()
       {
          this.Faculties = new List<SelectListItem>();
          this.Universities = new List<SelectListItem>();
       }  
    }
