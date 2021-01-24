        public Form1()
        {
            InitializeComponent();
            lvwColumns.LabelEdit = true;
            lvwColumns.AfterLabelEdit += lvwColumns_AfterLabelEdit;
        }
        private void lvwColumns_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(e.Label))
                e.CancelEdit = true;
        }
