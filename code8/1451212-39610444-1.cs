	protected virtual void WndProc(ref Message m) {
		// Something...
		switch (m.Msg) {
			// Something...
			case NativeMethods.WM_LBUTTONUP:
				WmMouseUp(ref m, MouseButtons.Left, 1); // Here will fire Click event
				break;
			// Something...
		} 
	}
