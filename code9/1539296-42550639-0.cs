    private void CheckFoo()
    {
        // It would be better to just not start the thread that
        // runs this method until the "Created" flag is set, rather
        // that having this busy loop to wait. At the very least, there
        // are better mechanisms for waiting than a loop like this.
        while (!this.Created)
        {
        }
        while (this.ContinueLoop)
        {
            if (new Point(this.foo.Property1 + 100, 500) != this.DesktopLocation)
            {
                this.Invoke(new Action(() =>
                {
                    this.DesktopLocation = new Point(this.foo.Property1 + 100, 500);
                }));
            }
        }
    }
