     var updateBuilder = Builders<Type>.Update.
                               .Set(x => x.NestedArray[-1].IsActive, false)
                               .Set(x => x.NestedArray[-1].IsDeleted, true);
    
    mongoDbRepository.UpdateOne( Builders<Type>.Filter.Where( 
       x => x.NestedArray.Any(c => c.Id == categoryId)), updateBuilder);
