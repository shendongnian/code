    // Some where in your code where you open the addHost form
    using(frmAddHost fa = new frmAddHost())
    {
        fa.HostAdded += hostAddedHandler;
        fa.ShowDialog();
    }
    ...
    private void hostAddedHandler(string host, string alias)
    {
        // I call loadHost but you can look at what has been added 
        loadHosts();
    }
