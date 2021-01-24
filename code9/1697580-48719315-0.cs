    Button[] button = new Button[numberOfButtons];
    for (int i=0; i<numberOfButtons; i++)
    {
        button[i] = new Button();
        button[i].Click += new System.EventHandler(WhateverYouLike);
        // ... some other property assignments, probably also rule-based
    }
    // ... and at a later time:
    for (int i=0; i<numberOfButtons; i++) button[i].Enabled = false;
