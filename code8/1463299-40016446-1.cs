    public decimal Listbox1opgeteld(decimal sum)
        {
            decimal temp = sum;
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                Convert.ToInt32(listBox1.Items);
                temp += Convert.ToDecimal(listBox1.Items[i].ToString());
    
            }
            return temp;
    
        }
