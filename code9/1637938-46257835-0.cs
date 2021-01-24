    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private async Task SendEmail()
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Preencha todos os campos", "Erro",
                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                await Email.SendEmail();
                MessageBox.Show("Nice");
            }
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            await SendEmail();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
    public class Email
    {
        public async static Task SendEmail()
        {
            await Task.Delay(10000);
        }
    }
