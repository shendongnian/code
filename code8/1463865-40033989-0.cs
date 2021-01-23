    namespace WindowsFormsApplication2
    {
        public partial class Form1 : Form
        {
            string[] usernames = { "user1", "user2" };
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                bool wasFound = false;
                for (int i = 0; i < usernames.Length; i++)
                    if (textBox1.Text == usernames[i] && textBox2.Text == "password")
                    {
                        wasFound = true;
                        break;
                    }
    
                if (wasFound)
                {
                    Form2 frm = new Form2();
                    frm.Show();
                    this.Hide();
                }
                else
                {
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox1.Text = "Wrong credentials!";
                }
    
            }
        }
    }
