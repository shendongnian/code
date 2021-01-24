    TappedGestureRecognizer single = new TappedGestureRecognizer();
    TappedGestureRecognizer double = new TappedGestureRecognizer();
    double.NumberOfTapsRequired = 2;
    single.Tapped += OnSingleTap;
    double.Tapped += OnDoubleTap;
    
    // assuming you're within a Control's context
    this.GestureRecognizers.Add(single);
    this.GestureRecognizers.Add(double);
    
    protected void OnSingleTap(object sender, EventArgs e) {
    }
    
    protected void OnDoubleTap(object sender, EventArgs e) {
    }
