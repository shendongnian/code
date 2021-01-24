        for (int i=1; i<=5; i++)
     {
       Label myLabel = new Label();
    
       // Set the label's Text and ID properties.
       myLabel.Text = "Label" + i.ToString();
       myLabel.ID = "Label" + i.ToString();
       PlaceHolder1.Controls.Add(myLabel);
       // Add a spacer in the form of an HTML <br /> element.
       PlaceHolder1.Controls.Add(new LiteralControl("<br />"));
     } 
    
