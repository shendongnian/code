    List<Item> items = new List<Item>()
            {
                new Item() { IsClosed = true },
                new Item() { IsClosed = true },
                new Item() { IsClosed = true }
            };
    var allValuesAreTrue = items.All(it => it.IsClosed);
    var onlyOneValueIsTrue = items.Count(it => it.IsClosed) == 1;
