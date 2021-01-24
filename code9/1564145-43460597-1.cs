    public static class RuleExtension {
        public static bool Contains(this Rule rule, TimeSpan input) {
            var value = TimeSpan.Parse(input.ToString());
            var start = rule.From;
            var end = rule.To;
            if (end < start) {
                //loopback
                end += TimeSpan.FromHours(24);
                if (value < start)
                    value += TimeSpan.FromHours(24);
            }
            return start.CompareTo(value) <= 0 && value.CompareTo(end) < 0;
        }
    }
