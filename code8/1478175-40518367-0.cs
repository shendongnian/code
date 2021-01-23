     var list1 = new List<Object>();
    list1.Add(new Object { Name = "Object1", Value = 1 });
    list1.Add(new Object { Name = "Object2", Value = 1 });
    list1.Add(new Object { Name = "Object3", Value = 1 });
    list1.Add(new Object { Name = "Object4", Value = 1 });
    list1.Add(new Object { Name = "Object5", Value = 1 });
    var list2 = new List<Object>();
    list2.Add(new Object { Name = "Object1", Value = 1 });
    list2.Add(new Object { Name = "Object2", Value = 1 });
    var total = from item1 in list1
                join item2 in list2
                on item1.Name equals item2.Name into list3
                from subset in list3.DefaultIfEmpty()
                select new Object
                {
                    Name = item1.Name,
                    Value = item1.Value + (subset == null ? 0 : subset.Value)
                };
