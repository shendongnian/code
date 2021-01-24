    public partial class Form1 : Form
    {
        public Form1() {
            InitializeComponent();
        }
        private void Calculate_btn_Click(object sender, EventArgs e) {
            InputTextbox.Text = Evaluate(InputTextbox.Text);
        }
        private string Evaluate(string equation) {
            try {
                return $"{new DataTable().Compute($"{equation.Trim()}", "")}";
            } catch (Exception Ex) {
                MessageBox.Show($"{Ex.Message}\n\n{equation.Trim()}", Ex.Source, MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return null;
        }
        private void InputTextbox_KeyPress(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (char)13) {
                InputTextbox.Text = Evaluate(InputTextbox.Text);
            }
        }
    }
