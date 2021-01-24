    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Xamarin.Forms;
    using Xamarin.Forms.Xaml;
    using Plugin.pbXSettings;
    using Plugin.Geolocator;
    using Plugin.Permissions;
    using Plugin.Permissions.Abstractions;
    using Plugin.DeviceInfo;
    using Plugin.DeviceInfo.Abstractions;
    
    [assembly: Xamarin.Forms.Dependency(typeof(DE2.ILocSettings))]
    
    namespace DE2
    {
    	
    	using Xamarin.Forms.PlatformConfiguration;
    
    	[XamlCompilation(XamlCompilationOptions.Compile)]
    	public partial class DataEntryForm : ContentPage
    	{
    		public DataEntryForm ()
    		{
    			InitializeComponent ();
    
    		}
    
    		
    		private async void  TurnLocationOn_OnClicked(object sender, global::System.EventArgs e)
    		{
    
    			var myAction = await DisplayAlert("Location", "Please Turn On Location", "OK","CANCEL");
    			if (myAction)
    			{
    				if (Device.RuntimePlatform == global::Xamarin.Forms.Device.Android)
    				{
    
    					//DependencyService.Get<ISettingsService>().OpenSettings();
    					global::Xamarin.Forms.DependencyService.Get<global::DE2.ILocSettings>().OpenSettings();
    
    
    
    				}
    				else
    				{
    					DisplayAlert("Device", "You are using some other shit", "YEP");
    				}
    			}
    			else
    			{
    				DisplayAlert("Alert","User Denied Permission","OK");
    			}
    			
    	
    			// 
    		}
    	}
    }
