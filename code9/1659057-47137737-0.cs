    using System;
    using System.Windows.Forms;
    
    namespace MyApplication.Controls
    {
        public class ScrollableListView : ListView
        {
            [System.Runtime.InteropServices.DllImport("User32.dll")]
            public static extern IntPtr PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);
    
            protected override void WndProc(ref Message m)
            {
                const int WM_MOUSEWHEEL = 0x020A;
                switch (m.Msg)
                {
                    case WM_MOUSEWHEEL:
                        if (m.HWnd == Handle)
                        {
                            if (Parent is TabPage)
                                PostMessage((Parent as TabPage).Handle, m.Msg, m.WParam, m.LParam);
                        }
                        break;
                    default:
                        base.WndProc(ref m);
                        break;
                }
            }
        }
    }
