    public partial class PhoneRecord
    {
        private CostCode _costCode;
        public CostCode UiCostCode
        {
            get { return _costCode; }
            set
            {
                _costCode = value;
                CostCodeId = _costCode != null ? _costCode.CostCodeId : 0;
            }
        }
    }
