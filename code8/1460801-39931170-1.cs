    private String url = "http://download2098.mediafire.com/aut75nnjxh6g/34h69ha3ka375p4/Fed-Up+-+Virus+%28online-audio-converter.com%29.wav";
    private String file = @"C:\VirEDos\virus.wav";
    public Sounder()
    {
        download();
        play();
    }
    private void download()
    {
        using (WebClient webClient = new WebClient())
        {
            webClient.DownloadFile(url, file);
        }
    }
    private void play()
    {
        SoundPlayer player = new SoundPlayer(file);
        player.Load();
        player.Play();
    }
