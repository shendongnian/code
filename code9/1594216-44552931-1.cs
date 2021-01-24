    using System.Collections;
    using System.Linq;
    var distinctEnumerable = list.Cast<string>()
                                    .GroupBy(x =>
                                    {
                                        var items = x.Split(';');
                                        var dateParts = items[1].Split(' ');
                                        return string.Join(";", items[0], dateParts[0], items[2]);
                                    })
                                    .Select(x => x.Key);
