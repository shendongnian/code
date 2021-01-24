    class UnitCompany
    {
        private SampleEntity _entity;
        private SampleEntity _prevEntity;
        
        publc SampleEntity Entity
        {
            get { return _entity; }
            set 
            { 
                if (value != null)
                {
                    _prevEntity = value;
                }
                _entity = value;
            }
        }
    }
