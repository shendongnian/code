    public class ProgramViewModel
        {
            [Required(ErrorMessage = "Please select at least one company")]
            public IEnumerable<string> YourCompanyIdList{ get; set; }
        }
