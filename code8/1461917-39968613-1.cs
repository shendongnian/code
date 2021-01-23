    public class SimplyInfoVm
    {
      public string Name { set;get;}
      [Required]
      public int SelectedStateId { set;get;}
      public List<SelectListItem> States { set;get;}
    }
