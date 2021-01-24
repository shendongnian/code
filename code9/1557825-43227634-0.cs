    private static readonly Dictionary<string, Section> validSectionsByName;
    
    static YourClass()
    {
        var validSections = new [] {
            new Section("section-a", 1),
            new Section("section-b", 2),
            new Section("section-c", 3),
            new Section("section-d", 4)
        };
        validSectionsByName = validSections.ToDictionary(s => s.Name);
    }
