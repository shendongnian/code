    public partial class TasksForm : Form
    {
        private Form TheoryForm_Child;
    
        public TasksForm()
        {
            InitializeComponent();
            FormClosing += TaskForm_FormClosing;
        }
    
        public void TheoryButton_Click(object sender, EventArgs e)
        {
            TheoryForm_Child = new TeoriForm();
            TheoryForm_Child.Show();
        }
    
        public void TaskForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(TheoryForm_Child != null)
                TheoryForm_Child.Close();
        }
    }
