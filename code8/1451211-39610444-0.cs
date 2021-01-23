	protected override void WndProc(ref Message m) { 
		switch (m.Msg) {
			// Something...
			case NativeMethods.WM_REFLECT + NativeMethods.WM_NOTIFY:
				NativeMethods.NMHDR nmhdr = (NativeMethods.NMHDR) m.GetLParam(typeof(NativeMethods.NMHDR));
				switch (nmhdr.code) {
					case NativeMethods.TCN_SELCHANGE:
						if (WmSelChange ()) // Here will fire the event {
							m.Result = (IntPtr)1;
							tabControlState[TABCONTROLSTATE_UISelection] = false;
							return;
						}
						else {
							tabControlState[TABCONTROLSTATE_UISelection] = true;
						}
						break;
				}
				break;
		}
		// Something...
		base.WndProc(ref m); // The Control WndProc
	}
