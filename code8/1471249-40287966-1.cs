			NSImage baseImage = new NSImage ("original.jpg", false);
			NSImage tinyImage = new NSImage (new CoreGraphics.CGSize (32, 32));
			tinyImage.LockFocus ();
			baseImage.DrawInRect (new CoreGraphics.CGRect (0, 0, 32, 32), new CoreGraphics.CGRect (0, 0, baseImage.Size.Width, baseImage.Size.Height), NSCompositingOperation.Copy, 1.0f);
			tinyImage.UnlockFocus ();
			NSBitmapImageRep rep = new NSBitmapImageRep (tinyImage.AsTiff ());
			NSData data = rep.RepresentationUsingTypeProperties (NSBitmapImageFileType.Jpeg);
			data.Save ("tiny.jpg", true);
