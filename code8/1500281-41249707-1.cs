    public partial class myWindow : Window
    {
        ComboBox cbCombo;                        //DECALRE HERE
        InitializeComponent();
        //Other stuff
        private void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
        {
            if (e.Control is ComboBox)
            {
                cmCombo = e.Control as ComboBox;          //INITIALIZE HERE
                cmCombo.DropDownStyle = ComboBoxStyle.DropDown;
                cmCombo.AutoCompleteSource = AutoCompleteSource.ListItems;
                cmCombo.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            }
        }
        private void dataGridView1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cbCombo != null) 
                    string value = cbCombo.Value.ToString();
                if (value != null && value != "")
                    Column1.Items.Add(value);
            }
        }
    }
