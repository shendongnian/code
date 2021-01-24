    #r "System.Xml.Linq"
    using System;
    using System.Linq;
    using System.Xml.Linq;
    var firstOneInList = (new List<string> {
        "foo", "foo2"
    }).First<string>();
