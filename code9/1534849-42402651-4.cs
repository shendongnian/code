    public EditBOL(string BOL, string Batch, string prodDate)
    {
            InitializeComponent();
            txtBOL.Text = BOL;
            txtBatch.Text = Batch;
            //Code to breakdown prodDAte variable comes here!!
            DateTime date = Convert.ToDateTime(prodDate);
            yearTextBox.Text = date.Year.ToString();
            monthTextBox.Text = date.Month.ToString();
            dayTextBox.Text = date.Day.ToString();
    }
