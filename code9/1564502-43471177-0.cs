    public DateTime Date {get;set;} // note no serialization attribs
    [DataMember(Name="date")]
    public string DateString {
        get { return Date.WhateverFormattingCodeYouWantHere(); }
        set { Date = value.WhateverParsingCodeYouWantHere(); }
    }
