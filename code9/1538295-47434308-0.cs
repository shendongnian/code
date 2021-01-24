    using Android.Widget;
    using Android.OS;
    using Xamarin.ActionSheet;
    using Android.Support.V4.App;
    using System.Collections.Generic;
    using Android.App;
    
    namespace ActionSheetTest
    {
    	[Activity (Label = "ActionSheetTest", MainLauncher = true, Icon = "@mipmap/icon")]
    	public class MainActivity : FragmentActivity,ActionSheet.IActionSheetListener
    	{
    	protected override void OnCreate (Bundle savedInstanceState)
    	{
    		base.OnCreate (savedInstanceState);
    
    		// Set our view from the "main" layout resource
    		SetContentView (Resource.Layout.Main);
    
    		// Get our button from the layout resource,
    		// and attach an event to it
    		Button button = FindViewById<Button> (Resource.Id.myButton);
    		
    		button.Click += delegate {
    			var actionSheet = new ActionSheet ();
    			actionSheet.Other_Button_Title = new List<string> (){ "Option1", "Option2" };
    			actionSheet.SetActionSheetListener (this);
    			actionSheet.Show (SupportFragmentManager);
    		};
    	}
    
    	public void onDismiss (ActionSheet actionSheet, bool isCancel)
    	{
    		System.Console.WriteLine ("onDismiss");
    	}
    
    	public void onOtherButtonClick (ActionSheet actionSheet, int index)
    	{
    		System.Console.WriteLine (index);
    	}
    }
    }
