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
            Geslachts = GetGeslachts();
        }
        private IEnumerable<SelectListItem> GetGeslachts()
        {
            return new List<SelectListItem> 
            {
                new SelectListItem 
                { 
                    Text = "Select ---", 
                    Value = string.Empty
                },
                new SelectListItem 
                { 
                    Text = "Male", 
                    Value = "1"
                },
                new SelectListItem 
                { 
                    Text = "Female", 
                    Value = "2"
                }
            }
        }
    }
