    using System;
    using Xamarin.Forms;
    #if __IOS__
    using CoreGraphics;
    using UIKit;
    using Xamarin.Forms.Platform.iOS;
    #endif
    #if __ANDROID__
    using Android.Runtime;
    using Android.Text;
    using Android.App;
    using Android.Util;
    using View = Android.Views.View;
    using Android.Content;
    using Android.Views;
    using Android.Widget;
    using RelativeLayout = Android.Widget.RelativeLayout;
    using Android.Graphics;
    using Android.Views.Animations;
    #endif
    namespace Mobile.Helpers
    {
        public static class DialogHelper
        {
            var result = CallApi(); //so this will be common
            #if __IOS__
            //create ios view etc. and use result
            #if __ANDROID__
            //create android view etc. and use result
            #endif
            
        }
    }
