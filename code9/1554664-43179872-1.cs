    var modelFromTemplate = organization.Models.FirstOrDefault(m => m.IsTemplate == true);
    var eagerLoadParams = modelFromTemplate.Parameters.ToList();
    //Change stuff as needed on the template here
    modelFromTemplate.Name = "Something New";
    modelFromTemplate.IsTemplate = false;
    //Save the new model
    _modelRepo.Add(modelFromTemplate);
    _modelRepo.SaveChanges();
