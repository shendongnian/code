    using System;
    using System.Linq;
    using System.Data;    
    DataTable db = <some table>;
    db.AsEnumerable().Select(x => Convert.ToDouble(x["SomeColumn"]));
