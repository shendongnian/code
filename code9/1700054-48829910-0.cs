    public class MyComboBox : ComboBox
    {
        public event EventHandler SelectedItemChanged;
        protected override void OnSelectedIndexChanged(EventArgs e)
        {
            base.OnSelectedIndexChanged(e);
            SelectedItemChanged?.Invoke(this, e);
        }
    }
