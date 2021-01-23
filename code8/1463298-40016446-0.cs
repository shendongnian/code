    public decimal Listbox1opgeteld(decimal sum)
        {
    
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Convert.ToInt32(listBox1.Items);
                sum += Convert.ToDecimal(listBox1.Items[i].ToString());
    
            }
            return sum;
    
        }
