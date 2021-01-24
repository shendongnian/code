    public MainPage()
    {
        this.InitializeComponent();
        string str1 = "weather data"; 
        Task talkingTask = talk(Textmeteo);
        string str2 = "hello world";
        talkingTask = talkingTask.ContinueWith(completedTask => talk(str2));
    }
    public async Task talk(string text)
    {
        // await...
    }
