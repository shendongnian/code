    public class Rights: ViewModelBase
    {
        public Rights()
        {
            _bSalesPIC = false;
            _bZone = false;
            ... (etc)
            _bAll = false;
        }
        private bool _bSalesPIC;
        public bool bSalesPIC
        {
            get { return _bSalesPIC; }
            set
            {
                Set(ref _bSalesPIC, value);
                TriggerAll();
            }
        }
		
		private bool _bZone;
        public bool bZone
        {
            get { return _bZone; }
            set
            {
                Set(ref _bZone, value);
                TriggerAll();
            }
        }
		
		private bool? _bAll;
        public bool? bAll
        {
            get { return _bAll; }
            set
            {
                Set(ref _bAll , value);
                
                if (value == true)
                {
                    _bSalesPIC = true;
                    _bZone = true;
                    RaisePropertyChanged("bSalesPIC");
                    RaisePropertyChanged("bZone");
                }
                else if (value == false)
                {
					_bSalesPIC = false;
                    _bZone = false;
                    RaisePropertyChanged("bSalesPIC");
                    RaisePropertyChanged("bZone");
                }
            }
        }
		
		private void TriggerAll()
        {
            if (_bSalesPIC && _bZone && etc)
                bAll = true;
            else if (!_bSalesPIC && !_bZone && etc)
                bAll = false;
            else
                bAll = null;
        }
