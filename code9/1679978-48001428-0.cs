     protected override void OnCreate(Bundle savedInstanceState)
     {
          base.OnCreate(savedInstanceState);
          SetContentView(Resource.Layout.screenTwo); // <-- Add this line
          label = FindViewById<TextView>(Resource.Id.textView1);
          label.Text = Intent.GetStringExtra("Extra");
     }
