    var groups = from c in TilesCollection
                     group c by c.Category into g
                     orderby g.Key
                     select g;
    this.cvs.Source = groups;
    // And moved ItemsSource here, since we need a more complex binding
    // Note that 'ZoomoutCollection' is the new named ListView
    ZoomoutCollection.ItemsSource = this.cvs.View.CollectionGroups;
