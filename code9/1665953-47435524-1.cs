        public Form1()
        {
            InitializeComponent();
            lvwColumns.LabelEdit = true;
            lvwColumns.AfterLabelEdit += ListView1_AfterLabelEdit;
        }
        private void ListView1_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Label))
                e.CancelEdit = true;
        }
