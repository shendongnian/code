            Dictionary<double, Data> DictA = new Dictionary<double, Data>();
            Dictionary<double, Data> DictB = new Dictionary<double, Data>();
            DictA.Add(0, new Data() { DATES = new DateTime(2001, 1, 1), ValueA = 100 });
            DictA.Add(1, new Data() { DATES = new DateTime(2001, 2, 1), ValueA = 150 });
            DictA.Add(2, new Data() { DATES = new DateTime(2001, 3, 1), ValueA = 400 });
            DictB.Add(0, new Data() { DATES = new DateTime(2001, 2, 1), ValueB = 200 });
            DictB.Add(1, new Data() { DATES = new DateTime(2001, 3, 1), ValueB = 400 });
            DictB.Add(2, new Data() { DATES = new DateTime(2001, 4, 1), ValueB = 300 });
            DictB.Add(3, new Data() { DATES = new DateTime(2001, 5, 1), ValueB = 150 });
            var tempDictA = DictA.Values.ToDictionary(x => x.DATES, x => x.ValueA);
            var tempDictB = DictB.Values.ToDictionary(x => x.DATES, x => x.ValueB);
            ObservableCollection<Data> result 
                = new ObservableCollection<Data>(tempDictB.Select(x => tempDictA.ContainsKey(x.Key) 
                ? new Data() { DATES = x.Key, ValueA = tempDictA[x.Key], ValueB = x.Value }
            : new Data() { DATES = x.Key, ValueA = null, ValueB = x.Value })
            .Concat(DictA.Where(x => !tempDictB.ContainsKey(x.Value.DATES))
            .Select(x => new Data() { DATES = x.Value.DATES, ValueA = x.Value.ValueA, ValueB = null }))
            .OrderBy(x => x.DATES));
