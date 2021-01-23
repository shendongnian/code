    using System;
    using Android.App;
    using Android.Content;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Android.OS;
    using System.Collections.Generic;
    using Android.Preferences;
    
    namespace App
    {
        [Activity(Label = "App", MainLauncher = true, Icon = "@drawable/icon")]
        public class MainActivity : Activity
        {
    
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                //to get data that already stored in Shared Preferences use prefs.get----
                //to put new data in Shared Preferences Editor use editor.put----
                ISharedPreferences prefs = PreferenceManager.GetDefaultSharedPreferences(this);
                ISharedPreferencesEditor editor = prefs.Edit();
                if (prefs.GetBoolean("is_login",false))
                {
                    //prefs.GetBoolean("key",defualt value)       
                    //here use is logged in alread now open main page but note 
                    //you need for exmaple his id to make some opration in main page after login 
                    Intent x = new Intent(this,typeof(Activity2));
                    StartActivity(x);
                }
                else
                {
                    //here user is not logged in now to can show login page and after that you need to put 
                    //in local setting login=true like that
                    editor.PutBoolean("is_login", true);
                    editor.Apply();
                }
            }
        }
    }
