     private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            var pattern = new Regex(@"(\w[0-9]{6})"); //This is a regex pattern, you can make it much more intelligent, like if you just want P or C chars to accepted rather than any letter
            var isThereMatch = pattern.Match(textBox.Text); // Is there a match?
            string strThingIwannaSAVE = isThereMatch.ToString(); //If there is save that string so you can manipulate it
            if (textBox.Text.Length > 6) //only execute the following code if you have enough characted in your box
            { 
            if (string.IsNullOrWhiteSpace(strThingIwannaSAVE)) //if there is no match or its just whitespaces for some reason, empty out your box or display a message or whatever else
            {
                MessageBox.Show("Wrong input");
                    textBox.Text = String.Empty;
            }
            else 
            {  
              //String is good, add it to a database? do something to it?
            }           
          }
        }
