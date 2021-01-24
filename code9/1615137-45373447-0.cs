        private static DynamicParameters ConstructDynamicParameters(Dictionary<string, object> conditionParameters)
        {
            var dynParms = new DynamicParameters();
            foreach (var kvp in conditionParameters)
            {
                if (kvp.Value is DateTimeUTC)
                    dynParms.Add(string.Format("@{0}", kvp.Key), new DateTimeUTCParameter((DateTimeUTC)kvp.Value));
                else
                    dynParms.Add(string.Format("@{0}", kvp.Key), kvp.Value);
            }
            return dynParms;
        }
