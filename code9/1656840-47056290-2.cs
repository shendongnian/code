            var datebaseModelDictionary = databaseModels
                .GroupBy(model => model.RIT_TYPE)
                .ToDictionary(models => models.Key, models => models.Count());
            
            var result = databaseModels
                .Select(model => new TypeDTO
                {
                Type = long.Parse(model.RIT_TYPE.ToString()),
                Name = model.RIT_NAME,
                DefType = byte.Parse(model.RIT_DEF_TYPE.ToString()),
                DefCode = byte.Parse(model.RIT_DEF_CODE.ToString()),
                SumOfEachType = datebaseModelDictionary
            });
