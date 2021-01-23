    public static IEnumerable<IBaseClass> OrderList(IEnumerable<IBaseClass> list)
        {
            return list.OrderBy(x => x.Value);
        }
 
    orderedAList = OrderList(subClassAList)
                .ToList();
