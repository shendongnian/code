    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Android.App;
    using Android.Locations;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Xamarin.Android;
    using Xamarin.Forms;
    using DE2;
    using DE2.Droid;
    
    
    //[assembly: Xamarin.Forms.Dependency(typeof(ILocSettings))]
    
    //Notice the use of LocationZ in registering below instead of ILocSettings
    [assembly: Xamarin.Forms.Dependency(typeof(LocationZ))]
    
    namespace DE2.Droid
    {
    	using System.Runtime.Remoting.Messaging;
    
    	using Android.Support.V4.View;
    	using Android.Support.V7.App;
    
    	using Xamarin.Forms;
    	using DE2;
    
    	
    	public class LocationZ : ILocSettings
    	{
    		public void OpenSettings()
    		{
    			LocationManager LM = (LocationManager)Forms.Context.GetSystemService(Context.LocationService);
    
    		
    			if (LM.IsProviderEnabled(LocationManager.GpsProvider)==false)
    			{
    				
    			
    							Context ctx = Forms.Context;
    							ctx.StartActivity(new Intent(Android.Provider.Settings.ActionLocationSourceSettings));
    
    				
    			}
    			else
    			{
    				//this is handled in the PCL
    			}
    		}
    
    
    	}
    }
    [![One][2]][2]
    [![Two][3]][3]
    [![Three][4]][4]
