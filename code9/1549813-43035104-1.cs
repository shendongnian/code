    public class DataGridView1 : Control, IDataGridView1
    {
        TableLayoutPanel layoutPanel;
        public DataGridView1()
        {
            layoutPanel = new TableLayoutPanel();
            // Set up the layoutPanel.
            // Rest of constructor, define your controls.
            // Add your controls to layoutPanel.
            // Add layoutPanel to this control.
            Controls.Add(layoutPanel);
        }
        
        // Methods etc...
    }
