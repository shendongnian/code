    foreach (var list in listOfLists)
            {
                foreach (var apiModel in list)
                {
                    var objectData = apiModel.GetDataObject();
                    EMME_Context.Domains.Add(objectData);
                    listOfDomainData.Add(objectData);
                    try{
                      totalChanges += EMME_Context.SaveChanges();
                    }
                     catch(SqlException se){
                        if(se.Number != 2601) // Unique key violation
                        {
                           // Handle other errors
                        }
                     }
                }
    }
