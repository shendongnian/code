    Dictionary<string, string> abbr = new Dictionary<string, string>() {    
                                                                        {"Jan","JA"},
                                                                        { "Feb","FE"},
                                                                        { "Mar","MR"},
                                                                        { "Apr","AL"},
                                                                        { "May","MA"},
                                                                        { "Jun","JN"},
                                                                        { "Jul","JL"},
                                                                        { "Aug","AU"},
                                                                        { "Sep","SE"},
                                                                        { "Oct","OC"},
                                                                        { "Nov","NO"},
                                                                        { "Dec","DE"}
                };
    string val = Convert.ToDateTime(DateTime.Now).ToString("ddMMMyyyy",
                                            System.Globalization.CultureInfo.InvariantCulture);
    var newstr = abbr.Aggregate(val, (current, value) =>
     current.Replace(value.Key, value.Value));
