    public class SimplyInfoVm
    {
      public string Name { set;get;}  // to Display some name
      [Required]
      public int SelectedStateId { set;get;}
      public List<SelectListItem> States { set;get;}
    }
