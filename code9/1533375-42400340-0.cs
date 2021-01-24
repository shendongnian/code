    public class ListBoxThatWorks : ListBox
    {
        private int LatestIndex = -1;
        private object LatestValue = null;
        public EqualityComparer<object> ValueComparer { get; set; }
        public override int SelectedIndex
        {
            get { return base.SelectedIndex; }
            set { SetSelectedIndex(value); }
        }
        private void NotifyIndexChanged()
        {
            if (base.SelectedIndex != LatestIndex)
            {
                LatestIndex = base.SelectedIndex;
                base.OnSelectedIndexChanged(EventArgs.Empty);
            }
        }
        private void NotifyValueChanged()
        {
            if (!(ValueComparer ?? EqualityComparer<object>.Default).Equals(LatestValue, base.SelectedValue))
            {
                LatestValue = base.SelectedValue;
                base.OnSelectedValueChanged(EventArgs.Empty);
            }
        }
        private void SetSelectedIndex(int value)
        {
            base.SelectedIndex = value;
            NotifyIndexChanged();
            NotifyValueChanged();
        }
    }
