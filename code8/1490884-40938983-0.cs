    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.View> e)
                {
        			base.OnElementChanged (e);
        
        			if (e.NewElement != null) {
        				((MapView)Control).GetMapAsync (this);
        			}
        		}
    public void OnMapReady (GoogleMap googleMap)
    		{
    			map = googleMap;
    		}
