        public string CodeAnalysisEnabled(XElement propertyGroup, string groupName)
        {
            return Check(propertyGroup, groupName, "RunCodeAnalysis");
        }
        public string WarningsAsErrorsEnabled(XElement propertyGroup, string groupName)
        {
            return Check(propertyGroup, groupName, "TreatWarningsAsErrors");
        }
        private static string Check(XElement propertyGroup, string groupName, string checkedParam)
        {
            var codeAnalysis = (from doc in propertyGroup?.Descendants(checkedParam) select doc).ToArray();
            if (codeAnalysis.Length == 0)
            {
                return groupName + $": {checkedParam} is missing.";
            }
            var allOk = codeAnalysis.All(n => n.Value.Equals("true", StringComparison.InvariantCultureIgnoreCase));
            return allOk ? null : groupName + $": {checkedParam} has wrong state.";
        }
