     using (DocumentEntities dbConnection = new DocumentEntities())
     {
         if (dbConnection.CHECKs.Any(c => c.FUSION_CHECK_ID == fusionCheckID))
         {
             var currentCheck = dbConnection.CHECKs.Where(x => x.FUSION_CHECK_ID 
                                == check.CheckID && x.CHECK_STATUS_CD == 
                                "0").FirstOrDefault();
             if (currentCheck != null)
             {
                 PotentialChecks.Check.Add(check);
             }
          }
          else
          {
              PotentialChecks.Check.Add(check);
          }
     }     
