    public partial class CustomDialog : Form
    {
        // This static method is the equivalent of MessageBox.Show
        public static DialogResult ShowDialog(IWin32Window owner, string caption, string text)
        {
            using(var customDialog = new CustomDialog(caption, text))
            {
                return customDialog.ShowDialog(owner);
            }
        }
        // private constructor so you don't accidentally create an instance of this form
        private CustomDialog(string caption, string text)
        {
            InitializeComponent();
            this.Text = caption;
            this.message.Text = text;
        }
        // Handle the click event of the `yes` button
        private void yes_Click(object sender, EventArgs e)
        {
            // This will automatically close the form
            this.DialogResult = DialogResult.Yes;
        }
        // Handle the click event of the `no` button
        private void no_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }
    }
