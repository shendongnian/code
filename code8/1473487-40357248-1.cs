        public void Method0()
        {
            MessageBox.Show("method0")
        }
        public void Method1()
        {
            MessageBox.Show("method1");
        }
        public void Method2()
        {
            MessageBox.Show("method1");
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            System.Reflection.MethodInfo tmp = this.GetType().GetMethod("Method" + comboBox.SelectedIndex.ToString());
            if (tmp==null)
            {
                MessageBox.Show("method named '" + "Method" + comboBox.SelectedIndex.ToString() + "' dont exist");
            }
            else
            {
                tmp.Invoke(this, null);
            }
           
        }
