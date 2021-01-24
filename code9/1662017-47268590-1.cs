    GlobalKeyboardHook gkh = new GlobalKeyboardHook();
    private bool _winKeyPressed;
    
    public MyConstructor()
    {
        gkh.HookedKeys.Add(Keys.Left); //37
        gkh.HookedKeys.Add(Keys.Up); //38
        gkh.HookedKeys.Add(Keys.Right); //39
        gkh.HookedKeys.Add(Keys.Down); //40
    
        gkh.HookedKeys.Add(Keys.LWin); //91
        gkh.HookedKeys.Add(Keys.RWin); //92
    
        gkh.KeyDown += gkh_KeyDown;
        gkh.KeyUp += gkh_KeyUp;
    }
    
    private void gkh_KeyUp(object sender, KeyEventArgs e)
    { 
        if (e.KeyValue == 91 || e.KeyValue == 92)
        {
            // left or right windows key was released
            _winKeyPressed = false;
        }
    }
    
    void gkh_KeyDown(object sender, KeyEventArgs e)
    {
        if (e.KeyValue == 91 || e.KeyValue == 92)
        {
            // left or right windows key was pressed
            _winKeyPressed = true;
        }
    
        if (e.KeyValue == 39 && _winKeyPressed == true)
        {
            // right key
            MessageBox.Show("This works.");
        }
    }
