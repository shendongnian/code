    var document = subDocumentsCollection
        .Find(d => d.Id == "69c4f77d-05ef-431d-ae17-c076c6173e04")
        .Single();
    var page = document.Pages.Single(p => p.Id == "3d1497d7-f74c-4d88-b15c-bf2f9c736374");
    
    page.Title = "changed title";
    page.Slug = "changed slug";
    page.ModifiedAt = DateTime.UtcNow;
    
    subDocumentsCollection.ReplaceOne(d => d.Id == document.Id, document);
