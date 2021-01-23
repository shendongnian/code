     private void button1_Click(object sender, EventArgs e) {
       var lines = mylist
         .Where(item => radioButtonName.Checked && item.Name == textBoxSearch.Text ||
                        radioButtonAge.Checked && item.Age == textBoxSearch.Text ||
                        radioButtonGender.Checked && item.Gender == textBoxSearch.Text ||
                        radioButtonOccupation.Checked && item.Occu == textBoxSearch.Text)
         .Select(item => string.Format("Name: {0} Age: {1} Occupation: {2} Gender: {3}",
                                        item.Name, item.Age, item.Occu, item.Gender));  
       listBox1.Items.Clear();
       foreach (string line in lines)
         listBox1.Items.Add(line);   
     }  
