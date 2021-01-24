    class BaseForm : Form
    {
        public string PromptText
        {
            get { return textBox1.Text; }
            set { textBox1.Text = value; }
        }
        public int SelectedIndex
        {
            get { return comboBox1.SelectedIndex; }
            set { comboBox1.SelectedIndex = value; }
        }
        // etc.
    }
