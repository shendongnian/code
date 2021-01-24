    public EditBOL(string BOL, string Batch, string prodDate)
    {
            InitializeComponent();
            txtBOL.Text = BOL;
            txtBatch.Text = Batch;
            //Code to breakdown prodDAte variable comes here!!
            string[] tokens = prodDate.Split(' ')[0].Split('-');
            DateTime date = Convert.ToDateTime(prodDate);
            yearTextBox.Text = date.Year.ToString();
            monthTextBox.Text = date.Month.ToString();
            dayTextBox.Text = date.Day.ToString();
    }
