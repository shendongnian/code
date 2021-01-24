    using System;
    using System.Linq;
    using System.Data;    
    DataTable db = <some table>;
    double[][] arrayOfDoubles = db.AsEnumerable().Select(x => new [] { Convert.ToDouble(x["SomeColumn"]), Convert.ToDouble(x["SomeColumn"]), ... }).ToArray();
