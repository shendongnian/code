    public partial class Product: Form
    {
        public Form MainFormRef { get; set; }
        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
             // create new tab page to MainWindow form
             TabPage tabPage = new TabPage();
             tabPage.Text = form.Text;
             tabPage.Controls.Add(form);
    
             MainFormRef.MainTabControl.Controls.Add(tabPage);
             MainFormRef.MainTabControl.SelectedTab = tabPage;
        }
    }
