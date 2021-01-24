	protected override void OnMouseDown(MouseButtonEventArgs e) {
		popup.StaysOpen = true;
		popup.IsOpen = true;
		base.OnMouseDown(e);
	}
	protected override void OnMouseEnter(MouseEventArgs e) {
		popup.StaysOpen = false;
		base.OnMouseEnter(e);
	}
	protected override void OnMouseLeave(MouseEventArgs e) {
		popup.StaysOpen = false;
		base.OnMouseEnter(e);
	}
	protected override void OnLostMouseCapture(MouseEventArgs e) {
        // Function no longer needed
		base.OnLostMouseCapture(e);
	}
