        public partial class Form1 : Form, IMessageFilter
    {
        internal static int HIWORD(IntPtr wParam)
        {
            return (int)((wParam.ToInt64() >> 16) & 0xffff);
        }
        internal static int LOWORD(IntPtr wParam)
        {
            return (int)(wParam.ToInt64() & 0xffff);
        }
        [Flags]
        internal enum VIRTUAL_KEY_STATES
        {
            NONE = 0x0000,
            LBUTTON = 0x0001,
            RBUTTON = 0x0002,
            SHIFT = 0x0004,
            CTRL = 0x0008,
            MBUTTON = 0x0010,
            XBUTTON1 = 0x0020,
            XBUTTON2 = 0x0040
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINT
        {
            public int X;
            public int Y;
            public POINT(int x, int y)
            {
                X = x;
                Y = y;
            }
            public POINT(Point pt)
            {
                X = pt.X;
                Y = pt.Y;
            }
            public Point ToPoint()
            {
                return new Point(X, Y);
            }
            public void AssignTo(ref Point destination)
            {
                destination.X = X;
                destination.Y = Y;
            }
            public void CopyFrom(Point source)
            {
                X = source.X;
                Y = source.Y;
            }
            public void CopyFrom(POINT source)
            {
                X = source.X;
                Y = source.Y;
            }
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public RECT(Rectangle source)
            {
                Left = source.Left;
                Top = source.Top;
                Right = source.Right;
                Bottom = source.Bottom;
            }
            public RECT(int x, int y, int width, int height)
            {
                Left = x;
                Top = y;
                Right = Left + width;
                Bottom = Top + height;
            }
            public int Width
            {
                get { return Right - Left; }
            }
            public int Height
            {
                get { return Bottom - Top; }
            }
            public Rectangle ToRectangle()
            {
                return new Rectangle(Left, Top, Width, Height);
            }
            public void Inflate(int dx, int dy)
            {
                Left -= dx;
                Top -= dy;
                Right += dx;
                Bottom += dy;
            }
            public void Deflate(int leftMargin, int topMargin, int rightMargin, int bottomMargin)
            {
                Left += leftMargin;
                Top += topMargin;
                Right -= rightMargin;
                Bottom -= bottomMargin;
                if (Bottom < Top)
                {
                    Bottom = Top;
                }
                if (Right < Left)
                {
                    Right = Left;
                }
            }
            public void Offset(int dx, int dy)
            {
                Left += dx;
                Top += dy;
                Right += dx;
                Bottom += dy;
            }
        }
        [Flags]
        internal enum TOUCH_FLAGS
        {
            NONE = 0x00000000
        }
        [Flags]
        internal enum TOUCH_MASK
        {
            NONE = 0x00000000,
            CONTACTAREA = 0x00000001,
            ORIENTATION = 0x00000002,
            PRESSURE = 0x00000004,
        }
        internal enum POINTER_INPUT_TYPE
        {
            POINTER = 0x00000001,
            TOUCH = 0x00000002,
            PEN = 0x00000003,
            MOUSE = 0x00000004
        }
        [Flags]
        internal enum POINTER_FLAGS
        {
            NONE = 0x00000000,
            NEW = 0x00000001,
            INRANGE = 0x00000002,
            INCONTACT = 0x00000004,
            FIRSTBUTTON = 0x00000010,
            SECONDBUTTON = 0x00000020,
            THIRDBUTTON = 0x00000040,
            FOURTHBUTTON = 0x00000080,
            FIFTHBUTTON = 0x00000100,
            PRIMARY = 0x00002000,
            CONFIDENCE = 0x00004000,
            CANCELED = 0x00008000,
            DOWN = 0x00010000,
            UPDATE = 0x00020000,
            UP = 0x00040000,
            WHEEL = 0x00080000,
            HWHEEL = 0x00100000,
            CAPTURECHANGED = 0x00200000,
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINTER_TOUCH_INFO
        {
            [MarshalAs(UnmanagedType.Struct)]
            public POINTER_INFO PointerInfo;
            public TOUCH_FLAGS TouchFlags;
            public TOUCH_MASK TouchMask;
            [MarshalAs(UnmanagedType.Struct)]
            public RECT ContactArea;
            [MarshalAs(UnmanagedType.Struct)]
            public RECT ContactAreaRaw;
            public uint Orientation;
            public uint Pressure;
        }
        [StructLayout(LayoutKind.Sequential)]
        internal struct POINTER_INFO
        {
            public POINTER_INPUT_TYPE pointerType;
            public int PointerID;
            public int FrameID;
            public POINTER_FLAGS PointerFlags;
            public IntPtr SourceDevice;
            public IntPtr WindowTarget;
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtPixelLocation;
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtPixelLocationRaw;
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtHimetricLocation;
            [MarshalAs(UnmanagedType.Struct)]
            public POINT PtHimetricLocationRaw;
            public uint Time;
            public uint HistoryCount;
            public uint InputData;
            public VIRTUAL_KEY_STATES KeyStates;
            public long PerformanceCount;
            public int ButtonChangeType;
        }
        internal const int
           WM_PARENTNOTIFY = 0x0210,
           WM_NCPOINTERUPDATE = 0x0241,
           WM_NCPOINTERDOWN = 0x0242,
           WM_NCPOINTERUP = 0x0243,
           WM_POINTERUPDATE = 0x0245,
           WM_POINTERDOWN = 0x0246,
           WM_POINTERUP = 0x0247,
           WM_POINTERENTER = 0x0249,
           WM_POINTERLEAVE = 0x024A,
           WM_POINTERACTIVATE = 0x024B,
           WM_POINTERCAPTURECHANGED = 0x024C,
           WM_POINTERWHEEL = 0x024E,
           WM_POINTERHWHEEL = 0x024F,
           // WM_POINTERACTIVATE return codes
           PA_ACTIVATE = 1,
           PA_NOACTIVATE = 3,
           MAX_TOUCH_COUNT = 256;
        internal static int GET_POINTER_ID(IntPtr wParam)
        {
            return LOWORD(wParam);
        }
        [DllImport("user32.dll", SetLastError = true)]
        internal static extern bool GetPointerInfo(int pointerID, ref POINTER_INFO pointerInfo);       
        public bool PreFilterMessage(ref Message m)
        {            
            switch (m.Msg)
            {
                case WM_POINTERDOWN:
                case WM_POINTERUP:
                case WM_POINTERUPDATE:
                case WM_POINTERCAPTURECHANGED:
                    int pointerID = GET_POINTER_ID(m.WParam);
                    POINTER_INFO pi = new POINTER_INFO();
                    if (GetPointerInfo(pointerID, ref pi))
                    {
                        // Not a primary pointer => filter !
                        if ((pi.PointerFlags & POINTER_FLAGS.PRIMARY) == 0)
                        {
                            return true;
                        }
                    }
                    break;                                   
            }           
            return false;
        }    
