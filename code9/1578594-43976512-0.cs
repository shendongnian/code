    public partial class TasksForm : Form
    {
        Form _TheoryFor_Child = new TheoryForm();
        public TasksForm()
        {
          InitializeComponent();
          Closed += TasksForm_Closed;
        }
        private void TasksForm_Closed(object sender, EventArgs e)
        {
          _TheoryFor_Child.Close();
        }
        private void TheoryButton_Click(object sender, EventArgs e)
        {      
          _TheoryFor_Child.Show();
        }
    }
