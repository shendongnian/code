    protected override void OnCreate(Bundle savedInstanceState)
    {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.layout2);
        var clickButton = FindViewById<ImageButton>(Resource.Id.activity2_button);
        if (Intent != null)
        {
            string nameString = Intent.GetStringExtra("ButtonState");
            if (nameString.Equals("start"))
            {
                btnState = ButtonState.start;
                clickButton.SetImageResource(Resource.Drawable.ic_pi1);
            }
            else if (nameString.Equals("stop"))
            {
                btnState = ButtonState.stop;
                clickButton.SetImageResource(Resource.Drawable.ic_pi2);
            }
            else
            {
                btnState = ButtonState.ok;
            }
        }
    }
