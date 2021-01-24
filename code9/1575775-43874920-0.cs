    public class DefaultSelection
    {
        public IEnumerable<SelectListItem> Items { get; set; }
        //Set a property to hold the selected items IDs.
        public IEnumerable<string> SelectedItems { get; set; }
        public DefaultSelection()
        {
            //preselected features
            Items = new List<SelectListItem>
            {
                new SelectListItem { Text = "Item1", Selected = true},
                new SelectListItem { Text = "Item2", Selected = false},
                new SelectListItem { Text = "Item3", Selected = true}
            };
        }
    }
