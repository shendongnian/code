    private string word; // assign it when you get word from the dictionary
    private void button2_Click(object sender, EventArgs e)
    {
        if (textBox4.Text == word)
        {
            timer1.Enabled = false;         
            timer1.Stop();                  
            MessageBox.Show("You Guessed The Word !");
        }
    }
