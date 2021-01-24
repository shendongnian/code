        private void Form1_Load(object sender, EventArgs e)
        {
            Dictionary<int, string> dictionary = new Dictionary<int, string>();
            XmlDocument doc = new XmlDocument();
            doc.Load(@"D:\WindowsFormsApplication1\WindowsFormsApplication1\XMLFile1.xml");
            XmlNodeList elemList = doc.GetElementsByTagName("User");
            for (int i = 0; i < elemList.Count; i++)
            {
                string attrVal = elemList[i].Attributes["userID"].Value;
                dictionary.Add(Convert.ToInt32(attrVal), attrVal);
            }
            comboBox1.DataSource = new BindingSource(dictionary, null);
            comboBox1.DisplayMember = "Key";
            comboBox1.ValueMember = "Value";
        }
