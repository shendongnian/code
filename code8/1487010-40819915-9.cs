        public override void OnBackPressed()
        {
            base.OnBackPressed();
            GC.Collect();
            Finish();
        }
