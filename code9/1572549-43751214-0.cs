    using (SqlDataReader read = cmd.ExecuteReader())
                    {
                        if (read.read())
                        {
                            //display values as you did before
                        }
                        else
                        {
                           //if using winform include System.Windows.Forms and use 
                           //  something like the following,
                           var result = MessageBox.Show(message, caption,
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
    
                          //depending on the result either cancel the request of prompt 
                            // user for another try.
    
                             //If using wpf
    
                         //  Include Windows.message.messagebox and use the message 
                         //  box class in a similar fashion as above.  Check usage if 
                         //  you are not familiar with it.
                        }
                    }
                }
