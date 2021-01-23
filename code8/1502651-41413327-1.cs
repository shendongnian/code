    public class RegisterViewModel
    {
      [DataType(DataType.Password)]
      [Display(Name = "Confirm password")]
      public string ConfirmPassword { get; set; }
      
      //Mapping 
      public int DistrictId { get; set; }
      public virtual List<DistrictModel> District { get; set; }
    }
