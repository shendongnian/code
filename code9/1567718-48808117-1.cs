    SP.ListItemCollection collListItem = oList.GetItems(camlQuery);
    clientContext.Load(collListItem, (....)
    clientContext.ExecuteQuery();
    var outlist = (collListItem.ToList()
              .Select(item => new MyClass()
              {
                  ID = Convert.ToInt32(item["ID"])
              }) as IEnumerable<MyClass>)
              .ToList();
    return outlist;
