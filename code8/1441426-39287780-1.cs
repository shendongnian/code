    public class Data { public string Test { get; set; } }
    public class Data2 { public string Test { get; set; } }
    var source = new Data[3] {
        new Data { Test = "1" },
        new Data { Test = "2" },
        new Data { Test = "3" }
    };
    var target = new List<Data2>();
    ObjectCollection<List<Data2>, Data2>(source, target);
