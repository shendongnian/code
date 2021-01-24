    public class App : Application
    {
    	public App()
    	{
    		// The root page of your application
    		var content = new ContentPage
    		{
    			Padding = new Thickness(15, Device.OnPlatform(25, 5, 5), 15, 10),
    			Title = "test",
    			Content = new StackLayout
    			{
    				Spacing = 2,
    				BackgroundColor = Color.Yellow,
    				Children = {
    					new Label {
    						Text = "Test:"
    					},
    					new Editor {
    						Text = "Blaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa",
    						IsEnabled = false,
    						HorizontalOptions = LayoutOptions.Fill,
    						VerticalOptions = LayoutOptions.Fill
    					},
    				}
    			}
    		};
    
    		MainPage = new NavigationPage(content);
    	}
    }
