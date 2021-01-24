    var found = db.MyEntity
        .OrderByDescending(c => c.CreationTime)
        .Where(c => c.ParameterColumn == parameter)
        .Select(c => new { c.CreationTime })
        .First();
You should probably create a ViewModel of MyEntityType that has only the properties you require, and map these to a new instance of the ViewModel instead. You can then update the [ResponseType(typeof(MyEntityType))] attribute too.
