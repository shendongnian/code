     var selected =  string.Join(",", yourListBox.Items.GetSelectedItems());
    public static class Extensions
    {
        public static IEnumerable<ListItem> GetSelectedItems(
               this ListItemCollection items)
        {
            return items.OfType<ListItem>().Where(item => item.Selected);
        }
    }
