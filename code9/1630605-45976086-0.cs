    public class ToDoItem : EntityData
    {
        public string Text { get; set; }
        public bool Complete { get; set; }
        public Gender Sex { get; set; }
    }
    public enum Gender
    {
        [Display(Name = "EnumGenderMale")]
        Male = 0,
        [Display(Name = "EnumGenderFemale")]
        Female = 1
    }
