    ComponentCollection = new CollectionViewSource();
    ComponentCollection.Source = (from c in Components
                                  select new
                                  {
                                      Name = c.Name,
                                      Type = c.Type,
                                      Pos = ComponentTypePositions[c.Type.Identification]
                                  }).ToList();
    ComponentCollection.GroupDescriptions.Clear();
    ComponentCollection.GroupDescriptions.Add(new PropertyGroupDescription("Type"));
    ComponentCollection.SortDescriptions.Clear();
    ComponentCollection.SortDescriptions.Add(new SortDescription("Pos", ListSortDirection.Ascending));
    ComponentCollection.SortDescriptions.Add(new SortDescription("Name", ListSortDirection.Ascending));
    ComponentCollection.Filter += FilterComponent;
    ComponentCollection.View.Refresh();
