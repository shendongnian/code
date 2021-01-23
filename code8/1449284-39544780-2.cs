            private void GenerateRandomNumber()
            {                
                int userNumber= Convert.ToInt32(GeneratetextBox.Text);
 
                Random randomNumbers = new Random();
                 // loop until i is not les than userNumber
                for (int i = 0; i < userNumber; i++){  
                      // generate random number and add it to the list.
                      int randNumber= randomNumbers.Next(100);
                      listBox.Items.Add(randNumber);
                }
              }
              private void button1_Click(object sender, EventArgs e)
              {
                 listBox.Items.Clear();
                 GenerateRandomNumber();
               }
