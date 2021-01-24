    public class CodebehindOfSomeView
    {
        private readonly DispatcherTimer m_ClosePopupTimer = new DispatcherTimer { Interval = TimeSpan.FromMilliseconds(1) };
        public CodebehindOfSomeView()
        {
            InitializeComponent();
            m_ClosePopupTimer.Tick += ClosePopupTimer_Tick;
        }
        private void ClosePopupTimer_Tick(object _sender, EventArgs _e)
        {
            SomePopup.IsOpen = false;
        }
        private void PopupMouseOverControls_MouseEnter(object _sender, System.Windows.Input.MouseEventArgs _e)
        {
            m_ClosePopupTimer.Stop();
            SomePopup.IsOpen = true;
        }
        private void PopupMouseOverControls_MouseLeave(object _sender, System.Windows.Input.MouseEventArgs _e)
        {
            m_ClosePopupTimer.Start();
        }
    }
