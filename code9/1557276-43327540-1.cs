    using System.Runtime.InteropServices;
    ...
        protected override void OnScroll(ScrollEventArgs e) {
            if (e.Type == ScrollEventType.First) {
                LockWindowUpdate(this.Handle);
            }
            else {
                LockWindowUpdate(IntPtr.Zero);
                this.Update();
                if (e.Type != ScrollEventType.Last) LockWindowUpdate(this.Handle);
            }
        }
        [DllImport("user32.dll", SetLastError = true)]
        private static extern bool LockWindowUpdate(IntPtr hWnd);
