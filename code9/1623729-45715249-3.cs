    button.Click += async (s, e) =>
    {
        var result = await DisplayMessage("Title", "Content");
        System.Diagnostics.Debug.WriteLine(result + "=====================");
    };
