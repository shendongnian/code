    private void button1_Click(object sender, EventArgs e) {
    
     string[] array = this.Controls.OfType < TextBox > ().Select(r => r.Text).ToArray();
    
     for (int i = 0; i < 6; i++) {
        Console.WriteLine(array[i]); //This is used to dispaly array values
     }
    
    }
