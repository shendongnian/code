    public interface IPersonViewModel
    {
        [Required]
        string MobileNumber { get; set; }
    }
    public class PersonViewModel : IPersonViewModel
    {
        // this will NOT get the [Required] attribute from the interface
        public string MobileNumber { get; set; }
    }
