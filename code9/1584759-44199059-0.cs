    public partial class Form1 : Form
    {
        DataGridView[] grid = null;
        
        public void Form1_Load(object sender, EventArgs e)
        {    
            ...
            grid = new DataGridView[grid_num];
            ...
        } 
    }
