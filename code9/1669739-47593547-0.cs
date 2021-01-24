    	private static System.Drawing.Point GetWindowCornerLU(System.IntPtr hWnd){
		if(hWnd == System.IntPtr.Zero){throw new System.Exception("ERROR: Window handle is not referenced!");}
		
		WindowHandle.User32.Rect rect = new WindowHandle.User32.Rect();
		WindowHandle.User32.GetWindowRect(hWnd, ref rect);
		return new System.Drawing.Point(rect.left, rect.top);
	}
	
    #pragma warning restore 649
	public static void ClickOnPoint(System.IntPtr wndHandle, int x, int y, bool KeepCursor = false, bool RightButton = false, bool DoubleClick = false){
		int nTimes = 0;
		TPoint clientPoint;
		clientPoint.X = x;
		clientPoint.Y = y;
		
        System.Drawing.Point oldPos = System.Windows.Forms.Cursor.Position;
		
		//System.Windows.Forms.MessageBox.Show("Click to " + clientPoint.X + " / " + clientPoint.Y + "");
		if(DoubleClick){nTimes = 2;}else{nTimes = 1;}
		
        /// get screen coordinates
		//ClientToScreen(wndHandle, ref clientPoint);
		System.Drawing.Point prtLU = GetWindowCornerLU(wndHandle);
		clientPoint.X += prtLU.X;
		clientPoint.Y += prtLU.Y;
		//System.Windows.Forms.MessageBox.Show("Click to " + clientPoint.X + " / " + clientPoint.Y + "");
		
        /// set cursor on coords, and press mouse
        System.Windows.Forms.Cursor.Position = new System.Drawing.Point(clientPoint.X, clientPoint.Y);
        INPUT inputMouseDown = new INPUT();
        inputMouseDown.Type = 0; /// input type mouse
		if(RightButton){
			inputMouseDown.Data.Mouse.Flags = MOUSEEVENTF_RIGHTDOWN; ///right button down
		}else{
			inputMouseDown.Data.Mouse.Flags = MOUSEEVENTF_LEFTDOWN; /// left button down
		}
        INPUT inputMouseUp = new INPUT();
        inputMouseUp.Type = 0; /// input type mouse
		if(RightButton){
			inputMouseUp.Data.Mouse.Flags = MOUSEEVENTF_RIGHTUP; /// right button up
		}else{
			inputMouseUp.Data.Mouse.Flags = MOUSEEVENTF_LEFTUP; /// left button up
		}
		
        var inputs = new INPUT[] { inputMouseDown, inputMouseUp };
		
		for(int i=0;i<nTimes;i++){
			SendInput((uint)inputs.Length, inputs, System.Runtime.InteropServices.Marshal.SizeOf(typeof(INPUT)));
		}
		
        /// return mouse 
		if(!KeepCursor){System.Windows.Forms.Cursor.Position = oldPos;}
	}
}
