    public partial class Form1 : Form
    {
        List<WorkflowViewModel> workflowViewList = new List<WorkflowViewModel>();
        private void SetRunButtonState()
        {
            workflowViewList = GetSelectedWorkflows();
            button.Enabled = workflowViewList.Count > 0;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            SetRunButtonState();
        }
        private void checkedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            SetRunButtonState();
        }
        // Rest of class code omitted...
    }
