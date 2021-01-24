    public MainWindow()
    {
        InitializeComponent();
        Produkte produkte = new Produkte();
        produkte.Name1 = "Handstaubsauger";
        produkte.Name2 = "Fensterwascher";
        produkte.Name3 = "Dampfreiniger";
        produkte.Name4 = "Hochdruckreiniger";
        produkte.Name5 = "Geschenkgutschein";
        //  ADD THIS
        DataContext = produkte;
        // Regex für Email
        String regexEmail = @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-\w]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$";
        // Hier weitermachen
    }
