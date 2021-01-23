    public partial class AddMaterials : Form
    {
        WorkOrder wo;
    
        public AddMaterials(WorkOrder wo)
        {
            InitializeComponent();
            this.wo = wo;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //Adding Materials
            this.wo.materialsList.Add(material.Text);
        }
    
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }   
    }
