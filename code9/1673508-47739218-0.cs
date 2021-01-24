        public partial class Form1 : Form, IMessageFilter
       
        public bool PreFilterMessage(ref Message m)
        {
            const int WM_MOUSEWHEEL = 0x020A;
            if (m.Msg == WM_MOUSEWHEEL)
            {
                // The wheeldelta is stored in the highorder of WParam.
                // The value of which will be 120 (positive for forward, negative for backward).
                int hiWord = m.WParam.ToInt32() >> 16;
                // So use the delta as a way to increment/decrement the volume
                this.axVLCPlugin21.volume += 10 * (hiWord / 120);
                Trace.WriteLine("vol: " + this.axVLCPlugin21.volume);
             }
            return false;
        }
