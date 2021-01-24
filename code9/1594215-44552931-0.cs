    using System.Collections;
    using System.Linq;
    var distinctEnumerable = list.Cast<string>()
                                    .GroupBy(x => string.Join(";", x.Split(';').Take(3)))
                                    .Select(x => x.Key);
