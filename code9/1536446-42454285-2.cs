    // Potentially wrong - not properly attaching event handler
    CustomAMSOffices.ListChanged += listChanged;
    CustomAMSContacts.ListChanged += listChanged;
    // Probably correct - Now this will be creating new event handlers
    CustomAMSOffices.ListChanged += new PropertyChangedEventHandler(listChanged);
    CustomAMSContacts.ListChanged += new PropertyChangedEventHandler(listChanged);
