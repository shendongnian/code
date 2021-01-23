    using System;
    using System.Runtime.InteropServices;
    using System.Windows.Forms;
<!---->
    public class SampleForm : Form
    {
        [DllImport("user32.dll")]
        private static extern int TrackMouseEvent(ref TRACK_MOUSE_EVENT lpEventTrack);
        [StructLayout(LayoutKind.Sequential)]
        private struct TRACK_MOUSE_EVENT {
            public uint cbSize;
            public uint dwFlags;
            public IntPtr hwndTrack;
            public uint dwHoverTime;
            public static readonly TRACK_MOUSE_EVENT Empty;
        }
        private TRACK_MOUSE_EVENT track = TRACK_MOUSE_EVENT.Empty;
        const int WM_NCMOUSEMOVE = 0xA0;
        const int WM_NCMOUSEHOVER = 0x2A0;
        const int TME_HOVER = 0x1;
        const int TME_NONCLIENT = 0x10;
        public event EventHandler NonClientMouseHover;
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == WM_NCMOUSEMOVE) {
                track.hwndTrack = this.Handle;
                track.cbSize = (uint)Marshal.SizeOf(track);
                track.dwFlags = TME_HOVER | TME_NONCLIENT;
                track.dwHoverTime = 500;
                TrackMouseEvent(ref track);
            }
            if (m.Msg == WM_NCMOUSEHOVER) {
                var handler = NonClientMouseHover;
                if (handler != null)
                    NonClientMouseHover(this, EventArgs.Empty);
            }
        }
    }
