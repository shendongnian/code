    public partial class Form2 : Form
    {
        private DataRow _theRow;
        private bool _isNew;
        public Form2(DataRow theRow, bool isNew)
        {
            InitializeComponent();
            _theRow = theRow;
            _isNew = isNew;
        }
        private void Form2_Load(object sender, EventArgs e)
        {
            textName.Text = _theRow["Name"];
            // Etc
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            // This is your add / edit record save button
            // Here you would do stuff with your textbox values on form2
            // including validation
            if (!ValidateChildren()) return;
            if (_isNew)
            {
                // Adding a record
                productBindingSource.EndEdit();
                productTableAdapter.Update();
            }
            else
            {
                // Editing a record
            }
            this.Close();
        }
    }
