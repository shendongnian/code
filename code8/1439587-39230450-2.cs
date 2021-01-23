    [Export ("layoutSublayersOfLayer:"), CompilerGenerated]
    public virtual void LayoutSublayersOfLayer (CALayer layer)
    {
    	UIApplication.EnsureUIThread ();
    	if (layer == null) {
    		throw new ArgumentNullException ("layer");
    	}
    	if (base.IsDirectBinding) {
    		Messaging.void_objc_msgSend_IntPtr (base.Handle, Selector.GetHandle ("layoutSublayersOfLayer:"), layer.Handle);
    	}
    	else {
    		Messaging.void_objc_msgSendSuper_IntPtr (base.SuperHandle, Selector.GetHandle ("layoutSublayersOfLayer:"), layer.Handle);
    	}
    }
