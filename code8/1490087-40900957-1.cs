    protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Page> e)
    		{
    			base.OnElementChanged(e);
    			if (e.OldElement != null || Element == null)
    			{
    				return;
    			}
    			try
    			{
    				this.SetOnTouchListener(this);
    			}
    			catch (Exception e)
    			{
    				
    			}
    
    		}
