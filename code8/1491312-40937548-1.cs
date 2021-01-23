    private void button3_Click(object sender, EventArgs e) {
      double price = 0;
      if (listBox1.SelectedItem.ToString().IndexOf("Family_Pizza") > -1) {
        price = 22.95;
      }
      .
      .
      . 
      else if (listBox1.SelectedItem.ToString().IndexOf("Ben 'n' Jerry Pint") > -1) {
        price = 11.95;
      }
      
      double label_value = Convert.ToDouble(label2.Text.Replace("$", ""));
      label_value -= price;
      label2.Text = label_value.ToString("C");
      listBox1.Items.Remove(listBox1.SelectedItem);
    }
