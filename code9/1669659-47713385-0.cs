	public PurchaseProcessingResult ProcessPurchase (PurchaseEventArgs args)
		{
	
			if (String.Equals (args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal)) {
				var builder = ConfigurationBuilder.Instance (StandardPurchasingModule.Instance ());
				var appleConfig = builder.Configure<IAppleConfiguration> ();
				DateTime? data = validate (appleConfig.appReceipt, kProductIDSubscription);
				if (data == null) {
					Debug.Log ("data then purchased");
				} else {
					Debug.Log ("Date: " + data);
				}
				if (data != null) {
					//Here is your code for success subscribed
					isPurchased = true;
				}
				#endif
			}	
			
			else {
				Debug.Log (string.Format ("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
			}
			return PurchaseProcessingResult.Complete;
		}
