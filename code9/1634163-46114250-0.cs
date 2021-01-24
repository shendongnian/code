    public class PhoneRecord
    {
        public int CostCodeId { get; set; }
        private CostCode _costCode;
        public CostCode CostCode
        {
            get { return _costCode; }
            set
            {
                _costCode = value;
                CostCodeId = _costCode != null ? _costCode.CostCodeId : 0;
            }
        }
    }
