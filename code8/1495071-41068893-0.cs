    public enum SpotifyAction
    {
                PlayPause,
                Next,
                Previous,
                VolumeUp,
                VolumeDown,
                Mute,
                Quit
    };
    
    public static void controlSpotify(SpotifyAction sa)
    {
                BringToForeground("Spotify");
    
                switch (sa)
                {
                    case SpotifyAction.Next:
                        SendKeys.SendWait("^({RIGHT})");
                        break;
                    case SpotifyAction.Previous:
                        SendKeys.SendWait("^({LEFT})");
                        break;
                    case SpotifyAction.VolumeUp:
                        SendKeys.SendWait("^({UP})");
                        break;
                    case SpotifyAction.VolumeDown:
                        SendKeys.SendWait("^({DOWN})");
                        break;
                    case SpotifyAction.PlayPause:
                        SendKeys.SendWait(" ");
                        break;
                }
    }
