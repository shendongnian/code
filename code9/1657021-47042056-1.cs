    private HashSet<Keys> _keys = new HashSet<Keys>();
    
    public void Control_KeyDown(object sender, KeyEventArgs e)
    {
    	_keys.Add(e.KeyCode);
    }
    public void Control_KeyUp(object sender, KeyEventArgs e)
    {
    	_keys.Remove(e.KeyCode);
    }
    
    public bool IsKeyDown(Keys keyCode)
    {
    	return _keys.Contains(keyCode);
    }
