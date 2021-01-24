        List<string> CE = new List<string>();
        public string Prev1;
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Prev1))
            {
                CE.Remove(Prev1);
            }
            CE.Add(comboBox1.Text);
            Prev1 = comboBox1.Text;
        }
