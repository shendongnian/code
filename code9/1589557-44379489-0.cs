    var attributesICareAbout = new List<Attribute>
    {
        AllAttributes.Attribute("Quick"),
        AllAttributes.Attribute("Brown"),
        AllAttributes.Attribute("Fox"),
        AllAttributes.Attribute("Jumps"),
        AllAttributes.Attribute("Lazy"),
        AllAttributes.Attribute("Dogs")
    }
    .Where(x => x.Attributes().Intersect(attributesICareAbout).Count == 1);
