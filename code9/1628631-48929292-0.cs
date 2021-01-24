        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            //bind view to controller
			var viewNib = UINib.FromName("KeyboardView", null);
			View = viewNib.Instantiate(this, null)[0] as UIView;	
        }
