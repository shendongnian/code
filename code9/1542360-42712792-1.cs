        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView (Resource.Layout.Main);
            var button = FindViewById<Button>(Resource.Id.btnClick);
            button.Click+= //press 'tab' now
        }
