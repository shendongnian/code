    void Main()
    {
        var db = new Dictionary<string, Action>();
        db.Add("Music 1", PlaySound1);
	
        // Retrieve the method we're looking for and execute it
        db["Music 1"]();
    }
    private void PlaySound1()
    {
        // Play the sound
    }
