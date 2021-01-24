        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            var button = FindViewById<Button>(Resource.Id.btnClick);
            button.Click += Button_Click;
        }
        private void Button_Click(object sender, System.EventArgs e)
        {
            throw new System.NotImplementedException();
        }
