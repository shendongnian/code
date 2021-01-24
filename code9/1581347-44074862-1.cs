    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    namespace App4.Dialogs
    {
        public class CustomProgressDialog
        {
            private CustomProgressDialog() { }
            public static Dialog Show(Context context)
            {
                Dialog dialog = new Dialog(context, Android.Resource.Style.ThemeTranslucentNoTitleBar);
                dialog.SetContentView(Resource.Layout.custom_progress_dialog);
                dialog.Window.SetGravity(GravityFlags.Center);
                dialog.SetCancelable(true);
                dialog.CancelEvent += delegate { dialog.Dismiss(); };
                dialog.Show();
                return dialog;
            }
        }
    }
