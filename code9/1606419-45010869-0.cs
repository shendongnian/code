    public partial class ExceptionForm : Form
    {
        public delegate void SelectValueDelegate(string option);
        public event SelectValueDelegate ValueSelected;
        private void btnExpSubmit_Click(object sender, EventArgs e)
        {
            this.Close();
            if (this.ValueSelected!= null)
            {
                this.ValueSelected(this.comboBox1.GetItemText(this.comboBox1.SelectedItem));
            }
            return;
        }
    }
