        public static List<string> RetrieveAffCodes(string logInIDs, string logInID)
        {
            return logInIDs
            .Split("|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries)
            .Where(a => a.Split(',').Any(c => c.Trim().Equals(logInID)))
            .Select(a => a.Split(',').ToList()).FirstOrDefault();
        }
