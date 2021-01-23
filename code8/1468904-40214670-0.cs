    class WindowPlacementPersistenceBehavior : Behavior<Window>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.SourceInitialized += this.AssociatedObject_SourceInitialized;
            this.AssociatedObject.Closing += this.AssociatedObject_Closing;
        }
        protected override void OnDetaching()
        {
            this.AssociatedObject.SourceInitialized -= this.AssociatedObject_SourceInitialized;
            this.AssociatedObject.Closing -= this.AssociatedObject_Closing;
            base.OnDetaching();
        }
        private void AssociatedObject_Closing(object sender, CancelEventArgs e)
        {
            WINDOWPLACEMENT wp;
            NativeMethods.GetWindowPlacement(new WindowInteropHelper(this.AssociatedObject).Handle, out wp);
            
            // Here you can store the window placement
            ApplicationSettings.WindowPlacement = wp.ToString();
        }
        private void AssociatedObject_SourceInitialized(object sender, EventArgs e)
        {
            // Here you can load the window placement
            WINDOWPLACEMENT wp = WINDOWPLACEMENT.Parse(ApplicationSettings.WindowPlacement);
            if (wp.ShowCmd == NativeMethods.SW_SHOWMINIMIZED)
            {
                // Don't start in the minimized state
                wp.ShowCmd = NativeMethods.SW_SHOWNORMAL;
            }
            try
            {
                NativeMethods.SetWindowPlacement(new WindowInteropHelper(this.AssociatedObject).Handle, ref wp);
            }
            catch
            {
            }
        }
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
            public static RECT Parse(string input)
            {
                RECT result;
                string[] items = input.Split(';');
                result.Left = int.Parse(items[0]);
                result.Top = int.Parse(items[1]);
                result.Right = int.Parse(items[2]);
                result.Bottom = int.Parse(items[3]);
                return result;
            }
            public override string ToString()
            {
                return this.Left + ";" + this.Top + ";" + this.Right + ";" + this.Bottom;
            }
        }
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        private struct POINT
        {
            public int X;
            public int Y;
            public static POINT Parse(string input)
            {
                POINT result;
                string[] items = input.Split(';');
                result.X = int.Parse(items[0]);
                result.Y = int.Parse(items[1]);
                return result;
            }
            public override string ToString()
            {
                return this.X + ";" + this.Y;
            }
        }
        [Serializable]
        [StructLayout(LayoutKind.Sequential)]
        private struct WINDOWPLACEMENT
        {
            public int Length;
            public int Flags;
            public int ShowCmd;
            public POINT MinPosition;
            public POINT MaxPosition;
            public RECT NormalPosition;
            public static WINDOWPLACEMENT Parse(string input)
            {
                WINDOWPLACEMENT result = default(WINDOWPLACEMENT);
                result.Length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
                try
                {
                    string[] items = input.Split('/');
                    result.Flags = int.Parse(items[0]);
                    result.ShowCmd = int.Parse(items[1]);
                    result.MinPosition = POINT.Parse(items[2]);
                    result.MaxPosition = POINT.Parse(items[3]);
                    result.NormalPosition = RECT.Parse(items[4]);
                }
                catch
                {
                }
                return result;
            }
            public override string ToString()
            {
                return this.Flags + "/" + this.ShowCmd + "/" + this.MinPosition.ToString() + "/" + this.MaxPosition.ToString() + "/" + this.NormalPosition.ToString();
            }
        }
        private static class NativeMethods
        {
            public const int SW_SHOWNORMAL = 1;
            public const int SW_SHOWMINIMIZED = 2;
            [DllImport("user32.dll")]
            public static extern bool SetWindowPlacement(IntPtr hWnd, [In] ref WINDOWPLACEMENT lpwndpl);
            [DllImport("user32.dll")]
            public static extern bool GetWindowPlacement(IntPtr hWnd, [Out] out WINDOWPLACEMENT lpwndpl);
        }
    }
