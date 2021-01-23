    private void toolStripMenuItem_Click(object sender, EventArgs e) 
    {
        //I suppose this is MenuItem if it something else you should write correct control
    
        MenuItem item = (MenuItem)sender;
        int attributeValue = 0;
    
        if(sender.ID == "toolStripMenuItem1")
        {
            attributeValue=1
        }
        else if (sender.ID == "toolStripMenuItem2")
        {
           attributeValue=2
        }
        else if(sender.ID == "toolStripMenuItem3")
        {
           attributeValue=3
        }
    
        myFunction(attributeValue);
    }
