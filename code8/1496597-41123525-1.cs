    using System;
    using System.Drawing;
    using System.Runtime.InteropServices;
    
    namespace MouseCursorHelper
    {
        class CursorActualSize
        {
            public static Size GetActualSize()
            {
                Bitmap bmp;
                IntPtr hicon;
                ExternalDlls.CURSORINFO ci = new ExternalDlls.CURSORINFO();
                ExternalDlls.ICONINFO icInfo;
                ci.cbSize = Marshal.SizeOf(ci);
                if (ExternalDlls.GetCursorInfo(out ci))
                {
                    if (ci.flags == ExternalDlls.CURSOR_SHOWING)
                    {
                        hicon = ExternalDlls.CopyIcon(ci.hCursor);
                        if (ExternalDlls.GetIconInfo(hicon, out icInfo))
                        {
                            bmp = Bitmap.FromHbitmap(icInfo.hbmMask);
    
                            var x = 0;
                            var y = 0;
                            
                            for (var i = 0; i < bmp.Width; i++)
                            {
                                for (var j = 0; j < bmp.Height; j++)
                                {
                                    var a = bmp.GetPixel(i, j);
    
                                    if (a.R == 0 && a.G == 0 && a.B == 0)
                                    {
                                        if (i > x)
                                        {
                                            x = i;
                                        }
    
                                        if (j > y)
                                        {
                                            y = j;
                                        }
                                    }
                                }
                            }
    
                            bmp.Dispose();
                            if (hicon != IntPtr.Zero)
                            {
                                ExternalDlls.DestroyIcon(hicon);
                            }
                            if (icInfo.hbmColor != IntPtr.Zero)
                            {
                                ExternalDlls.DeleteObject(icInfo.hbmColor);
                            }
                            if (icInfo.hbmMask != IntPtr.Zero)
                            {
                                ExternalDlls.DeleteObject(icInfo.hbmMask);
                            }
                            if (ci.hCursor != IntPtr.Zero)
                            {
                                ExternalDlls.DeleteObject(ci.hCursor);
                            }
    
                            return new Size(x, y);
                        }
    
                        if (hicon != IntPtr.Zero)
                        {
                            ExternalDlls.DestroyIcon(hicon);
                        }
                        if (icInfo.hbmColor != IntPtr.Zero)
                        {
                            ExternalDlls.DeleteObject(icInfo.hbmColor);
                        }
                        if (icInfo.hbmMask != IntPtr.Zero)
                        {
                            ExternalDlls.DeleteObject(icInfo.hbmMask);
                        }
                    }
                }
    
                if (ci.hCursor != IntPtr.Zero)
                {
                    ExternalDlls.DeleteObject(ci.hCursor);
                }
    
                return new Size(0, 0);
            }
        }
    }
