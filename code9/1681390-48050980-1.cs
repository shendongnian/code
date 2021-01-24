    namespace XFGlossSample.Views
    {
        public class AboutPage : ContentPage
        {
            public AboutPage()
            {
                Title = "XFGloss Sample App";
                Padding = 10;
        
    			// Manually construct a multi-color gradient at an angle of our choosing
    			var bkgrndGradient = new Gradient()
    			{
    				Rotation = 150,
    				Steps = new GradientStepCollection()
    				{
    					new GradientStep(Color.White, 0),
    					new GradientStep(Color.White, .5),
    					new GradientStep(Color.FromHex("#ccd9ff"), 1)
    				}
    			};
        
                ContentPageGloss.SetBackgroundGradient(this, bkgrndGradient);
    				
                Content = { ... }
            }
        }
    }
