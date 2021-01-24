    public static Dictionary<string, Section> SectionDictionary(List<Section> sections) {
        var dict = new Dictionary<string, Section>();
        foreach (var section in sections)
            dict.Add(section.Name, section);
        return dict;
    }
