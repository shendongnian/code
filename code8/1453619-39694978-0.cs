        public static bool CheckPasswordRule(string password)
        {
            var isRuleAdhered = (Regex.Matches(password, "\\d").Count == 6 && Regex.Matches(password, "[a-z]").Count == 2);
            return isRuleAdhered;
        }
