    var sections = statements.GroupBy(x => x.Section).Select(y => y.ToList()).ToList();
    var result = new List<SectionCollection>();
    foreach (var section in sections)
    {
        SectionCollection thisSection = new SectionCollection() { Categories = new List<CategoryCollection>() };
        var categories = section.GroupBy(x => x.Category).Select(y => y.ToList()).ToList();
        foreach (var category in categories)
        {
            thisSection.Categories.Add(new CategoryCollection { Statements = category });
        }
        result.Add(thisSection);
    }
