        [ComVisible(true)]
        [Guid("XXXXXX-xxxx-xxx-xxx-XXXXX")]
        [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        public interface ICSharpCom
        {
            /// <summary>
            /// Displays the dialog in async mode
            /// </summary>
            [DispId(0)]
            void ShowOverviewDialogAsync(IntPtr eventHandle); 
        }
    
        //Implementation:        
        ...
		_resetEvent = new ManualResetEvent(false);
					m.SafeWaitHandle = new Microsoft.Win32.SafeHandles.SafeWaitHandle(eventHandle, ownsHandle);
		
		
		// ... at some later point in the method, when the window closes
		
		_resetEvent .Set()
