    TappedGestureRecognizer sng = new TappedGestureRecognizer();
    TappedGestureRecognizer dbl = new TappedGestureRecognizer();
    dbl.NumberOfTapsRequired = 2;
    sng.Tapped += OnSingleTap;
    dbl.Tapped += OnDoubleTap;
    
    // assuming you're within a Control's context
    this.GestureRecognizers.Add(sng);
    this.GestureRecognizers.Add(dbl);
    
    protected void OnSingleTap(object sender, EventArgs e) {
    }
    
    protected void OnDoubleTap(object sender, EventArgs e) {
    }
