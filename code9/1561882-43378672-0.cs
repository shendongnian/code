    // object definition
    public class AvaSpec : NativeWindow
    {
        protected override void WndProc(ref Message m)
        {
            // catch WndProc messages that AvaSpec defines as its own
            if (m.Msg == AvaSpec.WM_MEAS_READY || 
                m.Msg == AvaSpec.WM_APP || 
                m.Msg == AvaSpec.WM_DBG_INFOAs || 
                m.Msg == AvaSpec.WM_DEVICE_RESET)
            {
                WndProcMessageReceived(ref m);
            }
            // Call base WndProc for default handling
            base.WndProc(ref m);
        }
