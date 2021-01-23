        public static Dictionary<string, Dictionary<string, int>> GetAllEnums(Assembly assembly)
        {
            return assembly
                .GetTypes()
                .Where(t => t.IsEnum)
                .ToDictionary(t => t.Name, t =>
                    Enum.GetNames(t)
                        .Zip(Enum.GetValues(t).Cast<int>(), (Key, Value) => new { Key, Value })
                        .ToDictionary(kvp => kvp.Key, kvp => kvp.Value));
        }
