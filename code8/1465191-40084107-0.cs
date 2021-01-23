    public class InputDialog:Form
    {
        public string Result { get; set; }
        
        private void OK_Click(object sender, EventArgs e)
        {
            Result = txtResult.Text;
            this.Close();
        }
    }
