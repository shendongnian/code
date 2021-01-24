    public partial class Form1 : Form
    {
        // code...
        private void Form1_Load(object sender, EventArgs e)
        {
            // code...
            modelBindingSource.DataSource = db2.Models.ToList();
            // code...
        }
    
        private void btnEdit_Click(object sender, EventArgs e)
        {
            // code...
            using (FormModel frm = new FormModel(modelBindingSource.Current as Model))
            {
                // code...
            }
        }
    }
