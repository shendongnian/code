        private static readonly Dictionary<string, Section> validSections = new[] {
            new Section("section-a", 1),
            new Section("section-b", 2),
            new Section("section-c", 3),
            new Section("section-d", 4)
        }.ToDictionary(s => s.Name);
