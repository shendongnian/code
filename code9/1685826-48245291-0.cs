    public void PaymentDateChanged()
        {
            SeniorityBonusInfo.FortnightNumber = GetFortnight(SeniorityBonusInfo.PaymentDate.Value);
        }
    public SeniorityBonusDTO SeniorityBonusInfo
        {
            get { return _SeniorityBonusInfo; }
            set { Set(ref _SeniorityBonusInfo, value); }
        }
