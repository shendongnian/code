       private void button1_Click(object sender, EventArgs e)
        {
            Form3 form3 = FormFactory.Instance.GetForm("Form3") as Form1;
            if(form3!=null)
            {
                form3.checkedListBox1.Items.Add("Item" + form3.checkedListBox1.Items.Count);
            }
        }
