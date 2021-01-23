    private int _id = -1;
        public int SelectedId
        {
            get
            {
                return _id;
            }
            set
            {
                _id = value;
                if (_id >= 0) { _device = Devices[_id]; Debug.WriteLine(Devices[_id].DeviceName); }
                RaiseAllPropertiesChanged();
            }
        }
