    private Restaurant _selectedRestaurant;
    
    public Restaurant SelectedRestaurant
    {
      get {
        return _selectedRestaurant;
      }
      set {
         _selectedRestaurant = value;
         updateWeb();
      }
    }
    
    private void updateWeb() {
      var url = SelectedRestaurant.Website; 
      webView.LoadRequest(new NSUrlRequest(new NSUrl(url)));
    }
