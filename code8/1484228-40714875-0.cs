    class LicenseChecker
    {
        private Timer mTimer;
        public delegate void LicenseNotValidDelegate();
        public event LicenseNotValidDelegate LicenseNotValid;
        
        public LicenseChecker()
        {
            mTimer = new Timer();
            mTimer.Ticket += mTimer_Tick;
            mTimer.Interval = TimeSpan.FromSeconds(10);
        }
        public void Start()
        {
            mTimer.Start();
        }
        void mTimer_Tick(object sender, EventArgs e)
        {
            if(!CheckLicense())
                LicenseNotValid?.Invoke();
        }
        private bool CheckLicense()
        { ... }
    }
    ...
    public void Main()
    {
        var lLC = new LicenseChecker();
        lLC.LicenseNotValid += lLC_LicenseNotValid;
        lLC.Start();
    }
    void lLC_LicenseNotValid()
    {
        //code when license is not valid
    }
