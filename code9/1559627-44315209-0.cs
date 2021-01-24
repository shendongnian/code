    int lineCounter = 0;
    string user;
    List<string> passwords = new List<string>(File.ReadAllLines(pathtopass));//store passwords in a List array
    
    // Read the file and display it line by line.
    System.IO.StreamReader file = new System.IO.StreamReader("c:\\Users.txt");
    while((user = file.ReadLine()) != null)//this will read each line at a time till it reaches the end of the file
    {
       if(Usertext.Text == user)//check for the user
       {
       try{
    		if (passtext.Text == passwords[lineCounter])//check for the password stored in the respective line in the Password.txt
    		{
    			//do your thing-->
    			testing test = new testing();
    			test.Show();
    			return;
    		}
    		else
            {
                MessageBox.Show("User or password is incorrect. Please verify!!", "WARNING!!", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            }//Denies access and shows a warning.
    	}
    	catch(Exception frog)//catch any exception which might arise here
    	{
    		MessageBox.Show("Error: "+frog.Message.ToString());
    	}
       }
       lineCounter++;//increment the counter to fetch the next index
    }
    
    file.Close();//close the file after reading is complete
