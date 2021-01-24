    public partial class FormModel : Form
    {
        public FormModel(Model obj)
        {
            InitializeComponent();
    
            modelBindingSource.DataSource = obj;
        }
    
        private void FormModel_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult == DialogResult.OK)
            {
                if (string.IsNullOrEmpty(txtModelName.Text))
                {
                    MessageBox.Show("Есть пустые поля", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtModelName.Focus();
                    e.Cancel = true;
                    return;
                }
            }
        }
    }
