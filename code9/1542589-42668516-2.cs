    //some checkboxes
    CheckBox chkA = ...
    CheckBox chkB = ...
    CheckBox chkC = ...
    //build up your filters
    var filters = new List<Predicate<SomeEntity>>();
    filters.Add(e => chkA.Checked && e.IsA);
    filters.Add(e => chkB.Checked && e.IsB);
    filters.Add(e => chkC.Checked && e.IsC);
           
    //And now simply apply the filters
    var entities = ... //some enumerable of SomeEntity
    var filteredEntities = entities.Where(e => filters.All(filter => filter(e)));
