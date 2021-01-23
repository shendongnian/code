        public static bool CheckPasswordRule(string password)
        {
            var isRuleAdhered= false;
            isRuleAdhered = Regex.Matches(password, "\\d").Count == 6 && Regex.Matches(password, "[a-z]").Count == 2 && !Regex.IsMatch(password, "\\d{6}");
            return isRuleAdhered;
        }
