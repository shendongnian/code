        public static Dictionary<string, Dictionary<string, int>> GetAllEnums(Assembly assembly)
        {
            return assembly
                .GetTypes()
                .Where(t => t.IsEnum)
                .ToDictionary(t => t.Name, t =>
                    Enum.GetValues(t)
                        .Cast<int>()
                        .ToDictionary(v => Enum.GetName(t, v)));
        }
