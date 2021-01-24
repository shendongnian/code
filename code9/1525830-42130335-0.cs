    namespace AttributeSyncExternal
    {
        public partial class AttributeSyncForm : Form
        {
            public AttributeSyncForm()
            {
                InitializeComponent();
            }
    
            public string BlockName
            {
                get { return blockNameInput.Text; }
                set { blockNameInput.Text = value; }
            }
    
            private void btnOk_Click(object sender, EventArgs e)
            {
                DialogResult = DialogResult.OK;
            }
        }
    }
