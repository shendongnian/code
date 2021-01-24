    public void action(string content)
    {
        var alert = new RadDesktopAlert
        {
            CaptionText = "Telefonmøde",
            ContentText = content
        };
        alert.Show();
    }
