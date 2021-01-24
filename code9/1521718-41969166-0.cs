    public class ViewModel
    {
        public List<SelectListItem> Statuses { get; set; }
    }
    
    
    // in controller
    ViewModel model = new ViewModel();
    
    // assumes listStatuses is still your ListStatus type.
    model.Statuses = listStatuses.Select(s => new SelectListItem() { 
        Text = s.Name, 
        Value = s.StatusID.ToString(),
    
        // or whatever your criteria may be.
        Selected = s.Name == "22222222-2222-2222-2222-222222222222"
    })
