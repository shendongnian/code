            public string Create()
        {
            string a;
            a = "This is a test";
            
            return a;
        
        }
        private void Gets()
        {
            string Value = Create();
            MessageBox.Show(Value);
            
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Gets();
        }
