      public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var projectB = new ProjectB();
                projectB.OnUpdateStatus += projectB_OnUpdateStatus;
                projectB.Run();
            }
    
            private void projectB_OnUpdateStatus(string message)
            {
                MessageBox.Show(message);
            }
        }
    public class ProjectB
    {
        public delegate void StatusUpdateHandler(string message);
        public event StatusUpdateHandler OnUpdateStatus;
        
        public void Run()
        {
            OnUpdateStatus("Updated");
        }
    }
