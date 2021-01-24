    Dictionary<string, System.Windows.Media.MediaPlayer> players = new Dictionary<string, System.Windows.Media.MediaPlayer>();
    var mp = playSound(@"d:\music\file.mp3");
    players.Add(btn.Text, mp); //Identifying media player by button text
    // Later if a user press the button again and your default action is pause
    if(players.ContainsKey(btn.Text))
       players[btn.Text].Pause();
