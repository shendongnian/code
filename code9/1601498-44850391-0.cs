    var famType = new FilteredElementCollector(m_doc)
        .OfClass(typeof(Family))
        .FirstOrDefault(x => x.Name == "YourFamilyName");
    
    if (famType != null)
    {
        const BuiltInParameter testParam = BuiltInParameter.ELEM_FAMILY_PARAM;
        var pvp = new ParameterValueProvider(new ElementId((int)testParam));
        var fnrv = new FilterNumericEquals();
        var ruleValId = famType.Id;
        var paramFr = new FilterElementIdRule(pvp, fnrv, ruleValId);
        var epf = new ElementParameterFilter(paramFr);
    
        var results = new FilteredElementCollector(m_doc)
            .OfClass(typeof(FamilyInstance))
            .WherePasses(epf)
            .ToElements();
    }
