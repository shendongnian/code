    /// <summary>
        /// Function to capture if the user clicks outside of the form, in which case need to close this form.
        /// </summary>
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            // if click outside dialog -> Close Dlg
            if (m.Msg == 0x86) //0x86 = NativeConstants.WM_NCACTIVATE
            {
                if (this.Visible)
                {
                    if (!this.RectangleToScreen(this.DisplayRectangle).Contains(Cursor.Position))
                        QuitVar = 0;
                }
            }
        }
