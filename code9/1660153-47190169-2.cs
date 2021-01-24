        public Form1()
        {
            InitializeComponent();
            dgv.Columns.Add(new DataGridViewTextBoxColumn());
            dgv.Rows.Add("text");
            dgv.EditingControlShowing += (sender, args) =>
                                         {
                                             Debug.Print(((DataGridView)sender).CurrentRow.Index.ToString());
                                             dgv.EditingControl.TextChanged -= EditingControlOnTextChanged;
                                             dgv.EditingControl.TextChanged += EditingControlOnTextChanged;
                                         };
        }
        private void EditingControlOnTextChanged(object sender, EventArgs eventArgs)
        {
            Debug.Print(((TextBox) sender).Text);
        }
