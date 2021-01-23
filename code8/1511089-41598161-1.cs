    Table inContextVariable = db.TableName.Find(value.ID);
    var config = new MapperConfiguration(cfg => cfg.CreateMap<TableName, TableName>());
    var mapper = config.CreateMapper();
    TableName valueMapper = mapper.Map<TableName>(value);
    db.Entry(inContextVariable).State = EntityState.Modified;
    db.SaveChanges();
    return RedirectToAction("Index");
