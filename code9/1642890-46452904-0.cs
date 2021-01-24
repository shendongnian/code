    public MainPage()
    {
        this.InitializeComponent();
        MakeTalk();
    }
    private async void MakeTalk()
    {
        // Surround by a try catch as we have async void.
        string str1 = "weather data"; 
        await talk(Textmeteo);
        string str2 = "hello world";
        await talk(str2);
    }
    public async Task talk(string text)
    {
       // [...]
    }
