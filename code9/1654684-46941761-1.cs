    class BuildingPermit : IBuildingPermit
    {
        DateTime _issuanceDate;
        string _permitNo;
    
        public BuildingPermit(DateTime issuanceDate, string permitNo)
        {
            _issuanceDate = issuanceDate;
            _permitNo = permitNo;
        }
    
    
        public DateTime issuanceDate
        {
            get
            {
                return _issuanceDate;
            }
    
            set
            {
                _issuanceDate = value;
            }
        }
    
        public string permitNo
        {
            get
            {
                return _permitNo;
            }
            set
            {
                _permitNo = value;
            }
        }
    }
