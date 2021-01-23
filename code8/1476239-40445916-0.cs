     List<string> a = new List<string>();
     
    private void textBox1_Leave(object sender, EventArgs e)
        {
            
            if(a.Contains(textBox1.Text))
            {
                MessageBox.Show("Notify");
            }
            else
            {
                a.Clear();
                a.Add(textBox1.Text);
            }
        }
