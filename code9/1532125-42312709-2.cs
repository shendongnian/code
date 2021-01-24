    Asert.AreEqual(expectedEntities.Count(), result.Entities.Count());
    for (var i = 0: i < expectedEntities.Count(); i++)
    {
       var item = result.Entities.Where(i => i.PKey == expectedEntities[i].PKey && i.Name == expectedEntities[i].Name).SingleOrDefault();
       Assert.IsNotNull(item);
    }
