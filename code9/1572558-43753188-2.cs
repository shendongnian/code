        in xamarin forms
        
        if(await DisplayAlert(null,"Enable Bluetooth","Yes", "No"))
        {
           // Enablebluetooth here via custom service
        }
    
    
    For bluetooth implementation download this in nugget
    https://github.com/tbrushwyler/Xamarin.BluetoothLE/ or you can implement your own
    
    
    //IN PCL
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace Test.App
    {
        public interface IBluetoothService
        {
            void OpenBluetooth();
           
        }
    }
    
    
    
    
    In Android
    using System;
    using BluetoothLE.Core;
    using Android.Bluetooth;
    using Java.Util;
    using System.Collections.Generic;
    using BluetoothLE.Core.Events;
    
    namespace Test.App.Droid.Services
    {
        public class BluetoothService : IBluetoothService
        {
    	
    		public void OpenBluetooth()
            {
    		//native code here to open bluetooth
    		}
    	
    	}
    	
    }
    
    // register it on mainactivity
    
    
    
    // do the same in ios
