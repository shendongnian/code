    public AddressbooksController (IntPtr handle) : base (handle)
        {
			displayModel = "addressbooks";
        }
		private void loadAddressbooks()
		{
			var AppDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			addressbooks = AppDelegate.api.DeserializeEntities<YAddressbook>(Task.Run(async () => await AppDelegate.api.Get("Yaddressbooks")).Result);
		}
		public void loadAddresscards()
		{
			var AppDelegate = UIApplication.SharedApplication.Delegate as AppDelegate;
			addresscards = AppDelegate.api.DeserializeEntities<Ycard>(Task.Run(async () => await AppDelegate.api.Get("Ycards")).Result);
		}
		public override void PrepareForSegue(UIStoryboardSegue segue, NSObject sender)
		{
			base.PrepareForSegue(segue, sender);
			// do first a control on the Identifier for your segu
			if (segue.Identifier.Equals("segueShowAddress"))
			{
				var viewController = (AddresscardController)segue.DestinationViewController;
				viewController.card = Card2Display;
			}
		}
		public override void ViewDidLoad()
		{
			if (displayModel == "addressbooks")
			{
				loadAddressbooks();
				tableView.Source = new AddressbooksTableSource(addressbooks.data, this);
				this.NavigationController.Title = "Addressbücher";
			}
			else if (displayModel == "addresscards")
			{
				loadAddresscards();
				tableView.Source = new AddresscardsTableSource(addresscards.data, this);
				this.NavigationController.
			}
			base.ViewDidLoad();
		}
