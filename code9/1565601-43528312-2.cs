     [Serializable]
    [XmlRoot("ns0:Claims")]
    public class Claim
    {
        [XmlElement("ClientName")]
        public string ClientName { get; set; }
        [XmlElement("UWYear")]
        public string Uwyear { get; set; }
        [XmlElement("AgreementNo")]
        public string AgreementNo { get; set; }
        [XmlElement("BusinessType")]
        public string BusinessType { get; set; }
        [XmlElement("PeriodStart")]
        public DateTime? PeriodStart { get; set; }
        [XmlElement("PeriodEnd")]
        public DateTime? PeriodEnd { get; set; }
        [XmlElement("PolicyNo")]
        public string PolicyNo { get; set; }
        [XmlElement("PolicyHolder")]
        public string PolicyName { get; set; }
        [XmlElement("DateOfLoss")]
        public DateTime? DateOfLoss { get; set; }
        [XmlElement("ClaimNo")]
        public string ClaimNo { get; set; }
        [XmlElement("ClaimantName")]
        public string ClaimantName { get; set; }
        [XmlElement("ClaimedInsured")]
        public string ClaimedInsured { get; set; }
        [XmlElement("ReportDate")]
        public DateTime? ReportDate { get; set; }
        [XmlElement("CountryOfRisk")]
        public string CountryOfRisk { get; set; }
        [XmlElement("CountryOfLoss")]
        public string CountryOfLoss { get; set; }
        [XmlElement("TypeOfLoss")]
        public string TypeOfLoss { get; set; }
        [XmlElement("InsuranceCoverage")]
        public string InsuranceCoverage { get; set; }
        [XmlElement("LineOfBuisnessNo")]
        public int? LineOfBuisnessNo { get; set; }
        [XmlElement("LineOfBuisnessName")]
        public string LineOfBuisnessName { get; set; }
        [XmlElement("ClassOfBuisnessNo")]
        public int? ClassOfBuisnessNo { get; set; }
        [XmlElement("ClassOfBuisnessName")]
        public string ClassOfBuisnessName { get; set; }
        [XmlElement("CaptiveShare")]
        public int? CaptiveShare { get; set; }
        [XmlElement("OriginalCurrency")]
        public string OriginalCurrency { get; set; }
        [XmlElement("PaymentCurrency")]
        public string PaidInCurrency { get; set; }
        [XmlElement("TotalIncurredCaptiveShare")]
        public decimal? TotalIncurredCaptiveShare { get; set; }
        [XmlElement("PaidThisPeriod")]
        public decimal? PaidThisPeriod { get; set; }
        [XmlElement("PeriodDate")]
        public DateTime? PeriodDate { get; set; }
        [XmlElement("PaymentDate")]
        public DateTime? PaymentDate { get; set; }
        [XmlElement("TotalPaidCaptiveShare")]
        public decimal? TotalPaidCaptiveShare { get; set; }
        [XmlElement("RemainingReserveCaptiveShare")]
        public decimal? RemainingReserveCaptiveShare { get; set; }
        [XmlElement("Deductible")]
        public string Deductible { get; set; }
        [XmlElement("Recovery")]
        public string Recovery { get; set; }
        [XmlElement("LocationAdress")]
        public string LocationAdress { get; set; }
        [XmlElement("Address1")]
        public string Address1 { get; set; }
        [XmlElement("Addresstype")]
        public string Address2 { get; set; }
        [XmlElement("Postalzone")]
        public string PostalCode { get; set; }
        [XmlElement("City")]
        public string PostalLocation { get; set; }
        [XmlElement("Country")]
        public string Country { get; set; }
        [XmlElement("GeograficalDiversification")]
        public string GeograficalDiversification { get; set; }
        [XmlElement("Cause")]
        public string Cause { get; set; }
        [XmlElement("Status")]
        public string Status { get; set; }
        [XmlElement("CloseDate")]
        public DateTime? CloseDate { get; set; }
        [XmlElement("DevelopmentYear")]
        public string DevelopmentYear { get; set; }
        [XmlElement("TotalIncurredInsurerShare")]
        public decimal? TotalIncurredInsurerShare { get; set; }
        [XmlElement("TotalPaidInsurerShare")]
        public decimal? TotalPaidInsurerShare { get; set; }
        [XmlElement("RemainingReserveInsurerShare")]
        public decimal? RemainingReserveInsurerShare { get; set; }
    }
    //[ModelMetadataType(typeof(DmgRegisterMetaData))]
    [Serializable()]
    [XmlRoot("ns0:Claims")]
    public class ClaimsCollection
    {
        [XmlArray("Claims")]
        [XmlArrayItem("Claim", typeof(Claim))]
        public Claim[] Claim { get; set; }
    }
