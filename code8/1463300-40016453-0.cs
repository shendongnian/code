    private void button1_Click(object sender, EventArgs e)
    {
        decimal sum = 0;
        textBox1.Text = Convert.ToString(sum);
        Listbox1opgeteld(sum); 
    }
    public decimal Listbox1opgeteld(decimal sum) 
    {
        for (int i = 0; i < listBox1.Items.Count; i++)
        {
            Convert.ToInt32(listBox1.Items);
            sum += Convert.ToDecimal(listBox1.Items[i].ToString());
        }
        return sum;
    }
