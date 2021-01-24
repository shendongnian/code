    private void Form1_Load(object sender, EventArgs e)
    {
        // Fill data grid
        DataTable dataTable = new DataTable();
    
        dataTable.Columns.Add("QuestionID");
        dataTable.Columns.Add("Question");
        dataTable.Columns.Add("Answer");
    
        dataTable.Rows.Add(1, "5 + 4", "9");
        dataTable.Rows.Add(2, "Capital of Germany", "Berlin");
        dataTable.Rows.Add(23, "Angela ...", "Merkel");
        dataTable.Rows.Add(42, "Capital of France", "Paris");
    
        dataGridViewQuiz.DataSource = dataTable;
        // Hide id and answer
        dataGridViewQuiz.Columns["QuestionID"].Visible = false;
        dataGridViewQuiz.Columns["Answer"].Visible = false;
    }
    
    // function to check an individual answer from a given TextBox
    // against a given row in the datagrid.
    private bool CheckAnswer(DataGridViewRow dataGridViewRow, TextBox textBox)
    {
        string correctAnswer = dataGridViewRow.Cells["Answer"].Value.ToString();
        string givenAnswer = textBox.Text;
    
        bool isCorrect = string.Equals(correctAnswer, givenAnswer, StringComparison.CurrentCultureIgnoreCase);
    
        return isCorrect;
    }
    
    private void buttonCheck_Click(object sender, EventArgs e)
    {
        bool firstAnswerCorrect = CheckAnswer(dataGridViewQuiz.Rows[0], textBoxQ1);
        bool secondAnswerCorrect = CheckAnswer(dataGridViewQuiz.Rows[1], textBoxQ2);
        bool thirdAnswerCorrect = CheckAnswer(dataGridViewQuiz.Rows[2], textBoxQ3);
        bool fourthAnswerCorrect = CheckAnswer(dataGridViewQuiz.Rows[3], textBoxQ4);
    }
