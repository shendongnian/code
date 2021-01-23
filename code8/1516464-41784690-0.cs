    public class StudentViewModel
    {
        public string Geslacht { get; set; }
        public IEnumerable<SelectListItem> Geslachts { get; set; } 
        public StudentViewModel()
        {
            Geslachts = GetGeslachts();
        }
        public StudentViewModel(string geslacht)
        {
            Geslacht = geslacht;            
            Geslachts = GetGeslachts(geslact);
        }
        private IEnumerable<SelectListItem> GetGeslachts(string value = string.Empty)
        {
            return new List<SelectListItem> 
            {
                new SelectListItem 
                { 
                    Text = "Select ---", 
                    Value = string.Empty,
                    Selected = string.Empty == value
                },
                new SelectListItem 
                { 
                    Text = "Male", 
                    Value = "1", 
                    Selected = "1" == value 
                },
                new SelectListItem 
                { 
                    Text = "Female", 
                    Value = "2", 
                    Selected = "2" == value 
                }
            }
        }
    }
