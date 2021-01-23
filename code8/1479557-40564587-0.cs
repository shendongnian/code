     public class SampleViewModel
     {
        [Display(Name = "رشته")]
        [Required(ErrorMessage = "لطفا یکی از رشته ها را انتخاب نمایید")]
        public int ReshteId { get; set; }
        public List<SelectListItem> ReshteSelectListItems { get; set; }
        [Display(Name = "پایه تحصیلی")]
        [Required(ErrorMessage = "لطفا یکی از پایه ها را انتخاب نمایید")]
        public int PayeId { get; set; }
        public List<SelectListItem> PayeSelectListItems { get; set; }
        //other field....
     }
