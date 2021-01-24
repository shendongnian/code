    // Build your button with its specific properties
    Button button = new Button();
    button.ID = "Bttn_PDF";
    button.CssClass = "btn btn-warning btn-xs";
    // Wire up its click event
    button.Click += bttn_Click;
    // Add it to the form
    PlaceHolder1.Controls.Add(button);
