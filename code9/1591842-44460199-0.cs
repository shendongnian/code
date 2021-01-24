    var v2 = new List<ImageSource>();
    for (int i = 0; i < 10; i++)
    {
        v2.Add(new BitmapImage(
            new Uri("http://static.lolskill.net/img/champions/64/xayah.png")));
    }
    BlueTeam.ItemsSource = v2;
