    public class SurveyResponseVM
    {
        public int ID { get; set; } // this will be bound by the route value
        [Required(ErrorMessage = "Please select an area")]
        [Display(Name = "Area")]
        public int? SelectedArea { get; set; }
        public IEnumerable<SelectListItem> AreaList { get; set; }
        .... // other properties of assessment that you need for the view
        public List<QuestionVM> Questions { get; set; }
    }
