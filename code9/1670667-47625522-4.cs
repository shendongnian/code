    private bool Use2600 { get; set; }    
    // This method can return void, because always returning true is pointless
    public void OnDown(bool held)
    {
        // The only real logic in this method is which string to use, so the
        // if/else block and duplication of code can be reduced to the following
        // by using a ternary operator, and string interpolation
        string path = $"pack://siteoforigin:,,,/Themes/Test/Images/Controls/Atari {(Use2600 ? "2600" : "5200")}/Joystick.png"
    
        Controller2.Source = new BitmapImage(new Uri(path));
        Use2600 = !Use2600;
    }
