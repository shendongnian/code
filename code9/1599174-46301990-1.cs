    class CustomSwitchRenderer : SwitchRenderer
	{
		protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Switch> e)
		{
			base.OnElementChanged(e);
			this.Control.ThumbDrawable.SetColorFilter(this.Control.Checked ? Color.DarkGreen : Color.Red, PorterDuff.Mode.SrcAtop);
			this.Control.TrackDrawable.SetColorFilter(this.Control.Checked ? Color.Green : Color.Red, PorterDuff.Mode.SrcAtop);
			this.Control.CheckedChange += this.OnCheckedChange;
		}
		private void OnCheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
		{
			this.Control.ThumbDrawable.SetColorFilter(this.Control.Checked ? Color.DarkGreen : Color.Red, PorterDuff.Mode.SrcAtop);
			this.Control.TrackDrawable.SetColorFilter(this.Control.Checked ? Color.Green : Color.Red, PorterDuff.Mode.SrcAtop);
		}
	}
