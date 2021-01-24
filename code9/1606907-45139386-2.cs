    [Activity(Label = "App39", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            var upArrow = AppCompatResources.GetDrawable(this, Resource.Drawable.abc_ic_ab_back_material);
            upArrow.SetColorFilter(new Color(ContextCompat.GetColor(this, Android.Resource.Color.HoloBlueBright)), PorterDuff.Mode.SrcIn);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(upArrow);
            Button b = FindViewById<Button>(Resource.Id.button);
            b.Click += B_Click;
        }
        private void B_Click(object sender, System.EventArgs e)
        {
            Intent i = new Intent(this, typeof(MainActivity));
            StartActivity(i);
        }
    }
