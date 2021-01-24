    //group by 2 properties
    var result = data.GroupBy(d => new { d.DeviceID, d.IsBaseloadDefined })
                     .Select(g =>
                    {
                    //for each group we get IsBaseloadDefined property
                    var IsBaseloadDefined = g.Key.IsBaseloadDefined;
    
                    if (IsBaseloadDefined == 1)
                    {
                        return g.Count();
                    }
                    else
                    {
                        // here another select that return count:
    
                        //(SELECT COUNT(DORG.DeviceID) 
                        //FROM DeviceOrganization DORG
                        //    INNER JOIN Organization ORG ON DORG.OrganizationID = ORG.OrganizationID
                        //INNER JOIN BaseloadOrganization BO ON ORG.BaseloadOrganizationId = BO.OrganizationID
                        //INNER JOIN Baseload BL ON BO.BaseloadID = BL.BaseloadID
                        //WHERE DORG.DeviceID = D.DeviceID
                        //AND BL.RecursUntil >= GETDATE()
                        //GROUP BY DORG.DeviceID)
                        
                        //in this query you should return Count() of group
                        
                        return 1; //return group.Count() instead 1
                    }
                });
