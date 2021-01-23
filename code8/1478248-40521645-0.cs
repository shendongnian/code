     private void mRichTextBox_LinkClicked (object sender, LinkClickedEventArgs e)   
     {
      if(IsLink(e.LinkText)==true)
       {
         System.Diagnostics.Process.Start(e.LinkText);
       }
     }
