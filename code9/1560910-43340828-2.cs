    var cul = (CultureInfo) CultureInfo.InvariantCulture.Clone();                        
    // set DateTimeFormatInfo.AbbreviatedEraNames to "BLA"
    typeof(DateTimeFormatInfo).GetField("m_abbrevEraNames", BindingFlags.Instance | BindingFlags.NonPublic)
        .SetValue(cul.DateTimeFormat, new string[] {"BLA"});
    // set DateTimeFormatInfo.AbbreviatedEnglishEraNames to "BLA"
    typeof(DateTimeFormatInfo).GetField("m_abbrevEnglishEraNames", BindingFlags.Instance | BindingFlags.NonPublic)
        .SetValue(cul.DateTimeFormat, new string[] { "BLA" });
    var date = DateTime.Parse("AD03AD08", cul); // now it fails
    var date = DateTime.Parse("A.D.03A.D.08", cul); // still works because we
    // did not modify non-abbreviated era name
    var date = DateTime.Parse("BLA03BLA08", cul); // this one works
