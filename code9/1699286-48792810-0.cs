    public class CustomDataGridView: DataGridView
    {
        public CustomCombobox CustomCmb { get;set }
        protected override void OnCellClick(DataGridViewCellEventArgs e)
        {
            base.OnCellClick(e);
            if (e.RowIndex > -1)
            {
                //Send some text to CustomCombobox
                CustomCmb.ReceiveText(text); //Create this method in the custom combobox class, to separate responsibilities.
            }
        }
    }
