    var example = new GdsObservableCollection<GroupedQueryResults>(
                items.Where(a => a.SubCategory3 != "{template}")
                     .GroupBy(item => item.SubCategory1)
                     .Select(g => new GroupedQueryResults
                                  {
                                     SubCategory = g.Key,
                                     SectionHeader = g.Any(x => x.Id == "XYZ") ?
                                     "Category :" +  g.First(x => x.Id == "XYZ").NewValue :
                                     "Item - " + itemNumber
