     var entities = new List<EntityRecommendation>(result.Entities);
      if (entities.Any(e => e.Type == "IdNumber"))
            {
                entities.Add(new EntityRecommendation(type: "IdNumber") { Entity = entities.FirstOrDefault(e => e.Type == "IdNumber").Entity});
            }
