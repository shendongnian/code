     public override void OnResume()
            {
                    base.OnResume();
                    // Auto size the dialog based on it's contents
                    Dialog.Window.SetLayout(LinearLayout.LayoutParams.MatchParent, LinearLayout.LayoutParams.WrapContent);
                    Dialog.Window.SetGravity(GravityFlags.Bottom);
                    // Make sure there is no background behind our view
                    Dialog.Window.SetBackgroundDrawable(new ColorDrawable(Color.Transparent));
                    // Disable standard dialog styling/frame/theme: our custom view should create full UI
                    SetStyle(Android.Support.V4.App.DialogFragment.StyleNoFrame, Android.Resource.Style.Theme);
            }
