    public class ProgramViewModel
        {
            [Required(ErrorMessage = "Please select atleast one program")]
            public IEnumerable<string> YourCompanyIdList{ get; set; }
        }
