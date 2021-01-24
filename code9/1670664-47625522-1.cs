    private bool Use2600 { get; set; }    
    public bool OnDown(bool held)
        {
            if (Use2600)
            {
                string path = $"pack://siteoforigin:,,,/Themes/Test/Images/Controls/Atari 2600/Joystick.png";
    
                BitmapImage bitmap = new BitmapImage();
    
                bitmap.BeginInit();
    
                bitmap.UriSource = new Uri(path, UriKind.Absolute);
    
                bitmap.EndInit();
    
                Controller2.Source = bitmap;
            } else
            {
                string path2 = $"pack://siteoforigin:,,,/Themes/Test/Images/Controls/Atari 5200/Joystick.png";
    
                BitmapImage bitmap2 = new BitmapImage();
    
                bitmap2.BeginInit();
    
                bitmap2.UriSource = new Uri(path2, UriKind.Absolute);
    
                bitmap2.EndInit();
    
                Controller2.Source = bitmap2;
            }
            Use2600 = !Use2600;
    
            return true;
        }
