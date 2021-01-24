    public class TodoItem
    {
        public string Id { get; set; }
        [JsonProperty(PropertyName = "text")]
        public string Text { get; set; }
        [JsonProperty(PropertyName = "sex")]
        public Gender Sex { get; set; }
    }
    public enum Gender
    {
        [Display(Name = "EnumGenderMale")]
        Male = 0,
        [Display(Name = "EnumGenderFemale")]
        Female = 1
    }
