    public class MainView : Form, IMainView
    {
        public IDataGridView1 DataView1 { get; set; }
        public IDataGridView2 DataView2 { get; set; }
        public IDataGridView3 DataView3 { get; set; }
        TableLayoutPanel layoutPanel;
        
        public MainView(IDataGridView1 dataView1, IDataGridView2 dataView2,
                        IDataGridView3 dataView3)
        {
            this.DataView1 = dataView1;
            this.DataView2 = dataView2;
            this.DataView3 = dataView3;
            layoutPanel = new TableLayoutPanel();
            // Define your layout panel here.
            // Add your controls to layoutPanel.
            // Add layoutPanel to the MainView.
            Controls.Add(layoutPanel);
            
            // Rest of constructor...
        }
        
        // Hides other views and show DataView1.
        public void ShowOnlyDataView1()
        {
            DataView2.Hide();
            DataView3.Hide();
            DataView1.Show();
        }
        // Hides other views and show DataView2.
        public void ShowOnlyDataView2()
        {
            // Etc...
        }
        // Hides other views and show DataView3.
        public void ShowOnlyDataView3()
        {
           // Etc...
        }
        // Other Methods etc...
    }
