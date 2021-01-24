        static DateTime ParseDateTime(string input)
        {
            int dateInteger, timeInteger;
            var s = input.Split(' ');
            bool dateOK = int.TryParse(s[0], out dateInteger);
            bool timeOK = int.TryParse(s[1], out timeInteger);
            if (!dateOK || !timeOK) throw new FormatException("Invalid date/time string.");
            var newInput = String.Format("{0:00000000} {1:000000}", dateInteger, timeInteger);
            return DateTime.ParseExact(newInput, "yyyyMMdd hhmmss", System.Globalization.CultureInfo.InvariantCulture);
        }
