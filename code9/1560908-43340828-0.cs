    var cul = (CultureInfo) CultureInfo.InvariantCulture.Clone();                        
    // set DateTimeFormatInfo.AbbreviatedEraNames to "BLA"
    typeof(DateTimeFormatInfo).GetField("m_abbrevEraNames", BindingFlags.Instance | BindingFlags.NonPublic)
        .SetValue(cul.DateTimeFormat, new string[] {"BLA"});
    // set DateTimeFormatInfo.AbbreviatedEnglishEraNames to "BLA"
    typeof(DateTimeFormatInfo).GetField("m_abbrevEnglishEraNames", BindingFlags.Instance | BindingFlags.NonPublic)
        .SetValue(cul.DateTimeFormat, new string[] { "BLA" });
    var date = DateTime.Parse("AD03AD08", cul); // fails
    var date = DateTime.Parse("BLA03BLA08", cul); // works
