    var filter = Builders<SubDocument>.Filter
        .And(
            Builders<SubDocument>.Filter.Eq(d => d.Id, "69c4f77d-05ef-431d-ae17-c076c6173e04"), 
            Builders<SubDocument>.Filter.ElemMatch(x => x.Pages, p => p.Id == "3d1497d7-f74c-4d88-b15c-bf2f9c736374"));
    
    var update = Builders<SubDocument>.Update
                    .Set(c => c.Pages[-1].Title, "changed title")
                    .Set(c => c.Pages[-1].Slug, "changed slug")
                    .Set(c => c.Pages[-1].ModifiedAt, DateTime.UtcNow);
    
    subDocumentsCollection.UpdateOne(filter, update);
