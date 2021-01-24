    Func<ImageView, Android.OS.IParcelable> btnAction = PickSelected;
     private Android.OS.IParcelable PickSelected(ImageView img)
        {
            //// Insert logic here
            return Android.OS.IParcelable object;
        }
    var intentVP = new Android.Content.Intent(this, typeof(ViewPagerActivity));
    Bundle mb = new Bundle();
    mb.PutParcelable("bundle",btnAction.Invoke(ImageViewObject)); 
    StartActivity(intentVP);
