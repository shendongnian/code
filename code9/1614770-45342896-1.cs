     public decimal? Validate (string input)
        {
            decimal number;
            if (string.IsNullOrEmpty(input))
                return 0;
            if (decimal.TryParse(input, out number))
                return number;
            else return null;
        }
