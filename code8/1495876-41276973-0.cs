    public string Add(string v1,string v2)
            {
                int i1 = Convert.ToInt32(v1);
                int i2 = Convert.ToInt32(v2);
    
                return (i1 + i2).ToString();
            }
    label1.text=Add(textBox1.Text,textBox2.Text); // write into button click event
    
