    public class CheckBoxItem {
        public int UserId { get; set; }
        public string Name { get; set; }
        public double Data { get; set; }
        public bool Selected { get; set; }
    }
    public class CreateNewEventModel {
        [Required(ErrorMessage = "Error text")]
        [Display(Name = "Header name")]
        public string EventName { get; set; }
        public List<CheckBoxItem> CheckBoxDataItems { get; set; }
        public CreateNewEventModel() {
            CheckBoxDataItems = new List<CheckBoxItem>();
        }
    }
