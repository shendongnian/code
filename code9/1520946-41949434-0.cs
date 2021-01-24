    using System;
    
    using Xamarin.Forms;
    
    namespace PickerTitleColor
    {
    	public class App : Application
    	{
    		public App()
    		{
    			var picker = new Picker();
    			picker.Items.Add("Select an item");
    			picker.Items.Add("Item1");
    			picker.Items.Add("Item2");
    			picker.Items.Add("Item3");
    			picker.TextColor = Color.Red;
    			picker.SelectedIndex = 0;
    
    			picker.SelectedIndexChanged += (sender, e) => 
    			{
    				if (picker.SelectedIndex == 0)
    					picker.SelectedIndex = 1;
    			};
    
    			var content = new ContentPage
    			{
    				Title = "Custom Picker Title Color",
    				Content = picker
    			};
    
    			MainPage = new NavigationPage(content);
    		}
    	}
    }
