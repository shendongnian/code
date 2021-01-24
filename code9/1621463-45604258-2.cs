        public override void LayoutSubviews()
        {
            base.LayoutSubviews();
            HeadingLabel.Frame = new CGRect(5, 4, ContentView.Bounds.Width - 63, 25);
            CellImageView.Frame = new CGRect(ContentView.Bounds.Width - 63, 5, 33, 33);
        }
