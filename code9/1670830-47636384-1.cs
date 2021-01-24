    var phraseSources2 = phraseSources.Where(p => categorySources.Any(c => c.Id == p.CategoryId));
    phraseSources2.ForEachDo(item=> {
        item.OneHash = Math.Abs(item.Id.GetHashCode() % 10);
        item.TwoHash = Math.Abs(item.Id.GetHashCode() % 100);
    })
