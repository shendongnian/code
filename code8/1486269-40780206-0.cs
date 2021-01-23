    Label dateLabel = new Label();
    //...
    panel1.Controls.Add(dateLabel);
    
    RichTextBox placeTravelLabel = new RichTextBox();
    //...
    panel1.Controls.Add(placeTravelLabel);
    
    Button clearButton = new Button();
    //...
    clearButton.Click += new EventHandler((s, e) => 
        {
            panel1.Controls.Remove(dateLabel);
            panel1.Controls.Remove(placeTravelLabel);
        });
    panel1.Controls.Add(clearButton);
