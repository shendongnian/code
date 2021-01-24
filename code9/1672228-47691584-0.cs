    string input = "Main1";
        IEnumerable<ObservableCollection<SubItems>> ItemsforSelectedMainIem = _data.Where(x => x.ItemName == input).Select(x => x.SubItemsList);
        var e = ItemsforSelectedMainIem.GetEnumerator();
        while (e.MoveNext())
        {
            var v = e.Current.Select(x=>x.SubItemName).ToList();
            foreach (var item in v)
            {
                Console.WriteLine(item);
            }
        }
