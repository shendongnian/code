     protected void Page_Load(object sender, EventArgs e)
        {
            string file = "test.txt";
            string[] str = null;
            if (File.Exists(Server.MapPath(file)))
            {
                str = File.ReadAllLines(Server.MapPath(file));
            }
            foreach (string s in str)
            {
                TextBox1.Text = TextBox1.Text +"\n"  +s;
            }
        
        }
