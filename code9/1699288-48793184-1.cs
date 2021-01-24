    public class CustomCombobox : ComboBox
    {
        private CustomDataGridView dataGridView = new CustomDataGridView();
        public CustomCombobox()
        {
            dataGridView.YourNewEvent += DoStuffWithText;
        }
        private void DoStuffWithText(string text)
        {
            throw new NotImplementedException();
        }
    }
