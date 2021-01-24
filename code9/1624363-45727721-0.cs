    void HandleManToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
            {
                var s = sender as Switch;
                if (s !=  null)
    			{
                    WomanGenderSwitch.IsToggled = s.IsToggled == false;
    			}
            }
    
    
    
      void HandleWomanToggled(object sender, Xamarin.Forms.ToggledEventArgs e)
        {
            var s = sender as Switch;
    		if (s !=  null)
    		{
    			ManGenderSwitch.IsToggled = s.IsToggled == false;
    		}
        }
