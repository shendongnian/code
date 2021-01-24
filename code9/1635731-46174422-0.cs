    public class FastScrollingDataGridView : DataGridView
    {
        private int numberOfRowsPerScroll = 20;
        short GET_WHEEL_DELTA_WPARAM(IntPtr wParam)
        {
            var int32 = (int)wParam.ToInt64();
            var shifted = int32 >> 16;
            return (short)shifted;
        }
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x20a) //WM_MOUSEWHEEL = 0x20a
            {
                var zDelta = GET_WHEEL_DELTA_WPARAM(m.WParam) > 0 ? numberOfRowsPerScroll : -numberOfRowsPerScroll;
                var newValue = FirstDisplayedScrollingRowIndex - zDelta;
                if (newValue < 0) newValue = 0;
                this.FirstDisplayedScrollingRowIndex = newValue;
                return; 
            }
            base.WndProc(ref m);
        }
    }
