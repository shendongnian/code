    public virtual bool Focused {
            get {
                return IsHandleCreated && UnsafeNativeMethods.GetFocus() == Handle;
            }
        }
    public IntPtr Handle {
            get {
                if (checkForIllegalCrossThreadCalls &&
                    !inCrossThreadSafeCall &&
                    InvokeRequired) {
                    throw new InvalidOperationException(SR.GetString(SR.IllegalCrossThreadCall,
                                                                     Name));
                }
