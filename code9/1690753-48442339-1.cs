    this.Player.Shoot += this.ShootHandler;
    public void ShootHandler(object sender, ShootEventArgs e) // common to use e for event args
    {
        Console.WriteLine(e.Text); // print "Bang"
    }
