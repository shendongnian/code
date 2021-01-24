    public class TeamMemberVM
    {
        public int? TeamMemberId { get; set; }
        ....
        [Display(Name = "DanGrades")]
        public IEnumerable<int> SelectedDanGrades { get; set; }
        public IEnumerable<SelectListItem> DanGradesList { get; set; }
    }
