    using System.Collections;
    using System.Linq;
    ArrayList list = new ArrayList() {
        "1;06/07/2017 11:17:16;out;0",
        "1;06/07/2017 11:27:16;out;2",
        "1;06/07/2017 11:28:16;out;0",
        "1;06/07/2017 11:20:16;out;3"
    };
    var distinctEnumerable = list.Cast<string>()
        .GroupBy(x => {
            var items = x.Split(';');
            var dateParts = items[1].Split(' ');
            return string.Join(";", items[0], dateParts[0], items[2]);
        })
        .Select(x => x.Key);
