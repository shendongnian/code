        string word; // variable for random word generated word = RandomWord(); 
        // Calling random word generator method  
        private void button2_Click(object sender, EventArgs e) {    
             if(textBox2.Text != null && textBox2.Text.Trim() != string.Empty)
                {
                  if (textBox2.Text.Trim().ToLower() == word.Trim().ToLower())
                  {
                      label4.Text = "You Won";
                      MessageBox.Show("You Guessed The Word = " + (word), "You won");
                  }
                  else
                  {
                      DoesNotMatch();    
                  }
                } else { throw new ApplicationException("Invalid entry, please try again.");}
            }
