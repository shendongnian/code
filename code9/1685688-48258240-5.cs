    class MyClickableSpan : ClickableSpan
    {
        private MainActivity mainActivity;
        public MyClickableSpan(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        public override void OnClick(View widget)
        {
            Intent browserIntent = new Intent(Intent.ActionView, Uri.Parse("https://www.google.co.in/"));
            mainActivity.StartActivity(browserIntent);
        }
        public override void UpdateDrawState(TextPaint ds)
        {
            base.UpdateDrawState(ds);
            ds.Color = Color.Red;
            ds.UnderlineText = false;
        }
    }
