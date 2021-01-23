    interface IHasStringValueAndText {
        String Value { get; set; }
        String Text { get; set; }
    }
    public static List<T> GetList<T>(dynamic data) where T : IHasStringValueAndText, new() {
        var lst = new List<T>();
        foreach (var d in data) {
            lst.Add(new T { Value = d.Id.ToString(), Text = d.Name });
        }
        return lst;
    }
