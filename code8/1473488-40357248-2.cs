        public int Method0()
        {
            MessageBox.Show("method0");
            return 0;
        }
        public int Method1()
        {
            MessageBox.Show("method1");
            return 1;
        }
        public int Method2()
        {
            MessageBox.Show("method2");
            return 2;
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
                int result=(int)tmp.Invoke(this, null);
            }
           
        }
