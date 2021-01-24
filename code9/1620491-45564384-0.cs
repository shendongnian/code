            #region Suspend / resume drawing
        /// <summary>
        /// Method to stop drawing of the control (useful when doing data dumps etc)
        /// </summary>
        public void SuspendDrawing()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETREDRAW, (IntPtr)0, (IntPtr)0);
        }
        /// <summary>
        /// Method to restart drawing of the control if it has been stopped.
        /// </summary>
        public void ResumeDrawing()
        {
            NativeMethods.SendMessage(this.Handle, NativeMethods.WM_SETREDRAW, (IntPtr)1, (IntPtr)0);
            this.Refresh();
        }
        #endregion
