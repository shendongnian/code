    {
        SqlConnection con = new SqlConnection(@"Data Source=.;Initial Catalog=phonemo;Persist Security Info=True;User ID=sa;Password=***********");
    
        public Phone()
        {
            InitializeComponent();
        }
    
        private void Phone_Load(object sender, EventArgs e)
        {
    
    
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
    
    
            DialogResult dialogResult = MessageBox.Show("This will Clear Text", "New", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
            }
            else if (dialogResult == DialogResult.No)
            {
                //do something else
            }
    
          
    
    
            con.Open();
            String query = "INSERT INTO phonemoo (Fname,Sname,Mobile,Email,Catagory) VALUES ('"+ textBox1.Text +"','"+ textBox2.Text +"','"+ textBox3.Text +"','"+ textBox4.Text +"','"+ comboBox1.Text + "')";
    
         SqlDataAdapter sda = new SqlDataAdapter(query,con);
         sda.SelectCommand.ExecuteNonQuery();
    
         con.Close();
    
            textBox1.Text = "";
            textBox2.Clear();
            textBox3.Text = "";
            textBox4.Clear();
            comboBox1.SelectedIndex = -1;
            textBox1.Focus();
    
         MessageBox.Show("Inserted !!");
        }
    }
