    public class MainForm: Form
    {
        private void ButtonAddItem_Click(object sender, EventArgs e)
        {
            using(var addItemForm = new AddNewItemForm())
            {
                if(addItemForm.ShowDialog() == DialogResult.Ok)
                {
                    // here you can update your DataGridView
                    this.DataGridView.DataSource = df.get_view();
                }
            }
        }           
    }
