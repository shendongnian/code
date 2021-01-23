    public delegate void Del(string str);
    
    class AddMaterials
    {
        private Del addMaterialDelegate;
    
        public AddMaterials(Del AddMaterialDelegate) : Form
        {
            InitializeComponent();
            this.addMaterialDelegate = AddMaterialDelegate;
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            //Adding Materials
            addMaterialDelegate(material.Text);
        }
    }
