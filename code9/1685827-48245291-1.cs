     public class SeniorityBonusDTO : ValidatableModelBase
     {
        [Required]
        public DateTime? PaymentDate
        {
            get { return Read<DateTime?>(); }
            set { Write(value, nameof(PaymentDate), false); }
        }
        [Required]
        public decimal? CurrentBasicSalary
        {
            get { return Read<decimal?>(); }
            set { Write(value, nameof(CurrentBasicSalary), false); }
        }
        [Required]
        public BonusDays DaysOfSalary
        {
            get { return Read<BonusDays>(); }
            set { Write(value, nameof(DaysOfSalary), false); }
        }
        [Required]
        public Fortnight FortnightNumber
        {
            get { return Read<Fortnight>(); }
            set { Write(value, nameof(FortnightNumber), false); }
        }
        [Required]
        public decimal? SeniorityBonusPayment
        {
            get { return Read<decimal?>(); }
            set { Write(value, nameof(SeniorityBonusPayment), false); }
        }
    }
