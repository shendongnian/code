    class RadForm1
    {
        public RadForm1(DataAdapter adapter)
        {
            if (adapter == null)
                throw new ArgumentNullException("adapter");
    
            InitializeComponent();
            this.Adapter = adapter
        }
        private void Update_LeadInfo()
        {
            this.Adapter.UpdateLeads(new LeadsInfo(
                              CVR: txtCVR.Text,
                              Firma: txtFirma.Text,
                              /* ... */));
        }
    }
    class CustomAppointmentForm
    {
        public CustomAppointmentForm(DataAdapter adapter)
        {
            if (adapter == null)
                throw new ArgumentNullException("adapter");
    
            InitializeComponent();
            this.Adapter = adapter
        }
        private void Update_LeadInfo()
        {
            this.Adapter.UpdateLeads(new LeadsInfo(
                              CVR: txtCVR.Text,
                              Firma: txtFirma.Text,
                              /* ... */));
        }
    }
