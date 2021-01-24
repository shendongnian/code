        protected override void OnBindingContextChanged()
		{
			base.OnBindingContextChanged();
			var vm = (TestViewModel)BindingContext; // Warning, the BindingContext View <-> ViewModel is already set
			vm.SignatureFromStream = async () =>
			{
				if (SignatureView.Points.Count() > 0)
				{
					using (var stream = await SignatureView.GetImageStreamAsync(SignaturePad.Forms.SignatureImageFormat.Png))
					{
						return await ImageConverter.ReadFully(stream);
					}
				}
				return await Task.Run(() => (byte[])null);
			};
		}
