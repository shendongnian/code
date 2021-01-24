    public class YourForm : Form
    {
        public YourForm()
        {
            InitializeComponents();
            // register event handlers:
            Load += YourForm_Load;
            textBox33.TextChanged += textBox33_TextChanged;
        }
        private void YourForm_Load(object sender, EventArgs e)
        {
            UpdateButton13();
        }
        private void textBox33_TextChanged(object sender, EventArgs e)
        {
            UpdateButton13();
        }
        private void UpdateButton13()
        {
            button13.Visible = quantity > 0; // no need for if/else
        }
    }
