    private void textBox2_TextChanged(object sender, EventArgs e)
    {
        int n,key;
        if (!int.TryParse(txtBox2.Text, out n))
            return;
        else
           key = Convert.ToInt32(txtBox2.Text, 16);
    }
    
    private void button2_Click_1(object sender, EventArgs e)
    {
       textBox2.Text="";
    }
