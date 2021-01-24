        static string key = "Level solution";
        char[] chars = key.ToCharArray();
        void check (object sender)
        {
            var button = sender as Button;
            character = Convert.ToChar(button.Text);
            int i = 0;
            foreach (char c in chars)
            {
                //checks every character to mark them
                if (c == character)
                {
                    chars[i] = ' ';
                    //Makes character unusable for later use
                    //Anything you want now for true letters, for example showing pics or adding them to a label
                }
                i++;
            }
            //checks every character of key again, to see if player is won
            int count = 0;
            foreach (char c in chars) {
                if (c != ' ') count++;
                //Adds a number for anything expect space
            }
            if (count == 0)
            {
                MessageBox.Show("You won!");
            }
            
        }
