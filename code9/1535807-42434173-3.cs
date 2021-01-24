    public class CustomPopupSelectionNotification : Confirmation
    {
        public CustomPopupSelectionNotification()
        {
            Items = new List<string>();
            SelectedItem = null;
        }
        public CustomPopupSelectionNotification(IEnumerable<string> items) : this()
        {
            foreach (string item in items)
            {
                Items.Add(item);
            }
        }
        public IList<string> Items { get; private set; }
        public string SelectedItem { get; set; }
    }   
