     LinearLayout parentLayout = (LinearLayout)FindViewById(Resource.Id.daterow);
     //using Android.Widget;
     Android.Widget.LinearLayout Linear1 = new Android.Widget.LinearLayout(this);
     //using Android.Views.ViewGroup;
     Linear1.LayoutParameters = new Android.Views.ViewGroup.LayoutParams(Android.Views.ViewGroup.LayoutParams.MatchParent, Android.Views.ViewGroup.LayoutParams.WrapContent);
     parentLayout.AddView(Linear1);
     Android.Widget.TextView tv = new Android.Widget.TextView(this);
     tv.Text = DateTime.Now.AddMinutes(1.1).ToString("HH:mm");//THIS IS WHAT I WANT TO ACCOMPLISH EVENTUALLY
     Linear1.AddView(tv);  //THIS LINE FOR TESTING ONLY.
