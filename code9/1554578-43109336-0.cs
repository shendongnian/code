        public override bool IsValid(object value)
        {
            DateTime dateTime;
            var isValid = DateTime.TryParseExact(Convert.ToString(value),
                "M/yyyy",
                CultureInfo.CurrentCulture,
                DateTimeStyles.None,
                out dateTime);
            return isValid;
        }
    }
