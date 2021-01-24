    ListBox.SlectedObjectCollection TheSelectedItem = new ListBox.SlectedObjectCollection(listBox1);
    
    TheSelectedItem = listBox1.SelectedItems; 
    
    int sum = 0;
    private void button6_Click(object sender, EventArgs e) 
    {
       //also ensure that the row is selected before clicking the button that's the only way the SelectedIndex click event will fire, pass the selected row value.
    if(listBox1.TheSelectedItem.Count != 0)
    {
       while (listBox1.SelectedIndex != -1)
         {	 
    	    listBox1.Items.RemoveAt(listBox1.SelectedIndex);		
      		sum -= Convert.ToInt32(dataGridView1.CurrentRow.Cells[3].Value.ToSt‌​ring()); 
          }           
      }
         label7.Text = sum.ToString();         
    } 
