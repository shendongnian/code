        int guess = 0;
        while (guess != randNumber)
        {
            if !string.IsNullOrEmpty(txtbxInputNumber.Text)
            { 
               guess = int.Parse(txtbxInputNumber.Text);
               if (guess < randNumber)
               {
                   MessageBox.Show("Try higher");
               }
               else
               {
                   MessageBox.Show("Try lower");
               }
            }
        } 
.
