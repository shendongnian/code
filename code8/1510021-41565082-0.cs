    foreach (var list in listOfLists)
            {
                foreach (var apiModel in list)
                {
                    var objectData = apiModel.GetDataObject();
                    EMME_Context.Domains.Add(objectData);
                    listOfDomainData.Add(objectData);
                    totalChanges += EMME_Context.SaveChanges();
                }
    }
