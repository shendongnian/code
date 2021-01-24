    public class JooyaCheckBoxList : CheckBoxList
    {
        public JooyaCheckBoxList()
        {
            base.SelectedIndexChanged += JooyaCheckBoxList_SelectedIndexChanged;
            base.PreRender += JooyaCheckBoxList_PreRender;
        }
        private void JooyaCheckBoxList_PreRender(object sender, EventArgs e)
        {
            SelectedItems = Items.Cast<ListItem>().Where(li => li.Selected).ToList();
        }
        private static List<ListItem> SelectedItems { get; set; }
        private void JooyaCheckBoxList_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<ListItem> CurrentSelectedItems = Items.Cast<ListItem>().Where(li => li.Selected).ToList();
            if (CurrentSelectedItems.Count > SelectedItems.Count)
            {
                var li = CurrentSelectedItems.Except(SelectedItems).SingleOrDefault();
                OnSelectedPropertChaned(li);
            }
            else if (CurrentSelectedItems.Count < SelectedItems.Count)
            {
                var li = SelectedItems.Except(CurrentSelectedItems).SingleOrDefault();
                OnSelectedPropertChaned(li);
            }
            else
            {
                OnSelectedPropertChaned(null);
            }
        }
        public event EventHandler<ListItem> SelectedPropertyChaned;
        public void OnSelectedPropertChaned(ListItem changedItem)
        {
            SelectedPropertyChaned?.Invoke(this, changedItem);
        }
    }
