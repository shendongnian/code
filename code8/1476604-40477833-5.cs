    public class DeviceLogVM
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "..")] // add StringLength etc as needed
        public string Log { get; set; }
    }
