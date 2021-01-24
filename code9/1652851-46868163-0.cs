    class BCADDate : IComparable
    {
        public int Year { get; set; }
        public int Month { get; set; }
        public int Day { get; set; }
        public bool IsAD { get; set; }
        public static BCADDate Parse(string input)
        {
            var result = new BCADDate();
            if (string.IsNullOrWhiteSpace(input))
                throw new ArgumentException("input cannot be null, empty, or whitespace");
            
            var dateADParts = input.Split(' ');
            var dateParts = dateADParts[0].Split('/');
            if (dateParts.Length < 3)
                throw new FormatException(
                    "The string must have three parts separated by the '/' character.");
            try
            {
                result.Year = int.Parse(dateParts[0]);
                result.Month = int.Parse(dateParts[1]);
                result.Day = int.Parse(dateParts[2]);
            }
            catch
            {
                throw new FormatException(
                    "All parts of the date portion must be valid integers.");
            }
            result.IsAD = (dateADParts.Length == 1)
                ? true  // A.D. is true if nothing is specified
                : dateADParts[1].IndexOf("A", StringComparison.OrdinalIgnoreCase) > -1;
            return result;
        }
        public int CompareTo(object obj)
        {
            var other = obj as BCADDate;
            if (other == null) return 1;
            var BCMultiplier = IsAD ? 1 : -1;
            // Use default comparers for our fields
            if (this.IsAD != other.IsAD)
                return this.IsAD.CompareTo(other.IsAD);
            if (this.Year != other.Year)
                return this.Year.CompareTo(other.Year) * BCMultiplier;
            if (this.Month != other.Month)
                return this.Month.CompareTo(other.Month) * BCMultiplier;
            if (this.Day != other.Day)
                return this.Day.CompareTo(other.Day) * BCMultiplier;
            return 0;
        }
        public override string ToString()
        {
            var bcad = IsAD ? "A.D." : "B.C.";
            return $"{Year:0000}/{Month:00}/{Day:00} {bcad}";
        }
    }
