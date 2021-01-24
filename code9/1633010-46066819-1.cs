    private void button2_Click(object sender, EventArgs e)
    {
        string str="";
        for (int i = 0; i < checkedListBox1.Items.Count; i++)
        {
              if (checkedListBox1.GetItemChecked(i))
            {
                str += (string)checkedListBox1.Items[i];
              
            }
        }
         MessageBox.Show(str);
    }
