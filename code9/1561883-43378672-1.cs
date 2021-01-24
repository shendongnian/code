    // WinForm definition
    public partial class AvaSpec_X : Form
    {
        private AvaSpec AS = new AvaSpec();
        public AvaSpec_X()
        {
            InitializeComponent();
            AS.SpectrumMeasuredEvent += (se, ev) => { SpectrumMeasured(ev); };
            AS.Init(this.Handle);
            AS.Activate();
            // configure as desired
            //AS.l_PrepareMeasData.m_IntegrationDelay = 0;
            if (AS.DeviceList.Count > 0)
            {
                AS.Start();
            }
        }
