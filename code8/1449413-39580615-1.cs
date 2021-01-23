    namespace emailCheck
    {
      public partial class Form1 : Form
      {
        public Form1()
        {
            InitializeComponent();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            bool found = false;
            int lenght, index;
            index = 0;
            lenght = listBox1.Items.Count;
            label1.Text = Convert.ToString(listBox1.Items[index]);
            string pattern = null;
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            while ((found == false) && ( index < lenght))
            {
                if (Regex.IsMatch(textBox1.Text, Convert.ToString(listBox1.Items[index])))
                {
                    found = true;
                    MessageBox.Show("Not a valid Email address");
                }
                else
                {
                    index++;
                }
            }
            while (found == false)
            {
                if (Regex.IsMatch(textBox1.Text, pattern))
                {
                    found = true;
                    MessageBox.Show("Valid Email address");
                }
                else
                {
                    MessageBox.Show(" Invalid Email address");
                }
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add(textBox2.Text);
        }
        private void button3_Click(object sender, EventArgs e)
        {
                listBox1.Items.Remove(listBox1.SelectedItem);
        }
        private void label2_Click(object sender, EventArgs e)
        {
        }
      }
    }
