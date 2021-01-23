     private void mRichTextBox_LinkClicked (object sender, LinkClickedEventArgs)
     {      
       // Add this line inside this Event Handler.
         System.Diagnostics.Process.Start(e.LinkText);
       
        //This will only open Click Link in Default browser. Links will automatically get underlined as for hyperlinks. 
     }
