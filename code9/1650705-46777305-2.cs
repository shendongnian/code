	/// <summary>
	/// Gets the parameters that define the initial window style.
	/// </summary>
	protected override CreateParams CreateParams {
		get {
			CreateParams cp = base.CreateParams;
			if (!DesignMode) {
				cp.ClassStyle |= (int) ClassStyle.DoubleClicks;
				cp.Style |= unchecked((int) (WindowStyle.Popup | WindowStyle.SystemMenu | WindowStyle.ClipChildren | WindowStyle.ClipSiblings));
				cp.ExStyle |= (int) ExtendedWindowStyle.Layered;
			}
			return cp;
		}
	}
