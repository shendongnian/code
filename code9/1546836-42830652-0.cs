    public Dictionary<int, string> Barcodes
    {
        get { return (Dictionary<int, string>)Application["Barcodes"]; }
        set { Application["Barcodes"] = value; }
    }
