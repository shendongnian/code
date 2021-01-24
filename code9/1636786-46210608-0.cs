     public class Information
    {
        [RequiredIf("Address==null", ErrorMessage = "Number or Address is Required")]
        public string Number { get; set; }
        [RequiredIf("Number==null", ErrorMessage = "Number or Address is Required")]
        public string Address { get; set; }
    }
