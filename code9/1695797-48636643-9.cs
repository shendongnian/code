        public class AttributionInputWrapper : ModelWrapper<AttributionInput>
    {
        public AttributionInputWrapper(AttributionInput model) : base(model)
        {
        }
        public DateTime? StartDate
        {
            get => GetValue<DateTime?>();
            set
            {
                SetValue(value);
                if (EndDate < StartDate) EndDate = StartDate;
            }
        }
        public DateTime? EndDate
        {
            get => GetValue<DateTime?>();
            set
            {
                SetValue(value);
                if (EndDate < StartDate) StartDate = EndDate;
            }
        }
        protected override IEnumerable<string> ValidateProperty(string propertyName)
        {
            if (propertyName == nameof(EndDate) || propertyName == nameof(StartDate))
            {
                //if (StartDate.Value.Date > EndDate.Value.Date) yield return "Start Date must be <= End Date";
                if (EndDate != null && (EndDate.Value.DayOfWeek == DayOfWeek.Saturday || EndDate.Value.DayOfWeek == DayOfWeek.Sunday))
                    yield return "Please select a week day";
                if (StartDate != null && (StartDate.Value.DayOfWeek == DayOfWeek.Saturday || StartDate.Value.DayOfWeek == DayOfWeek.Sunday))
                    yield return "Please select a week day";
            }
        }
    }
