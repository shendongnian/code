    List<string> items = new List<string>();
            private void Form1_Load(object sender, EventArgs e)
            {
                items.Add("test");
                items.Add("asd");
                items.Add("qwe");
                comboBox1.DataSource = items;
                comboBox2.DataSource = items;
            }
