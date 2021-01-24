    public TwCapability(TwCap cap, short sval, TwType twtype)
    {
        Cap = (short)cap;
        ConType = (short)TwOn.One;
        Handle = Twain.GlobalAlloc(0x42, 6);
        IntPtr pv = Twain.GlobalLock(Handle);
        Marshal.WriteInt16(pv, 0, (short)TwType.Int16);
        Marshal.WriteInt32(pv, 2, (int)sval);
        Marshal.WriteInt16(pv, 0, (short)twtype);
        Twain.GlobalUnlock(Handle);
    }
    TwCapability capResx = new TwCapability(TwCap.ICAP_XRESOLUTION, 300, TwType.Fix32);
    rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capResx);
         
   
    TwCapability capResy = new TwCapability(TwCap.ICAP_YRESOLUTION, 300, TwType.Fix32);
    rc = DScap(appid, srcds, TwDG.Control, TwDAT.Capability, TwMSG.Set, capResy); 
