        public TransportViewModel()
        {
            ShowCommandParameter = new Command<Transport>(Show);
        }
        public void Show(Transport param)
        {
            // param contains the selected Transport
        }
