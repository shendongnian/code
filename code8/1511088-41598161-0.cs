    Table inContextVariable = db.TableName.Find(value.ID);
    Mapper.Initialize(config => config.CreateMap<ModelName, ModelName>());
    Mapper.Map<ModelName, ModelName>(value, inContextVariable);
    db.Entry(inContextVariable).State = EntityState.Modified;
    db.SaveChanges();
    return RedirectToAction("Index");
