    public static NSImage GetImageFromColor (NSColor color, float borderWidth = 1.0f)
    {
        var image = new NSImage (new CGSize (borderWidth, borderWidth));
        image.LockFocus ();
        color.DrawSwatchInRect (new CGRect (new CGPoint (0, 0), image.Size));
        image.UnlockFocus ();
        return image;
    }
