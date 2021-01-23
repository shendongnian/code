        private string _clientId;
        public string ClientId
        {
            get { return _clientId; }
            set
            {
                _clientId = value;
                RaisePropertyChanged();
                UIRepository.Instance.CurrentClientId = ClientId;
            }
        }
