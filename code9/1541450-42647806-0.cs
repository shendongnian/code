    var result = (from projectCost in db.ProjectCost 
                  join subCostType in db.SubCostType on projectCost.SubCostType equals subCostType.SubCostTypeId
                  join costType in db.CostType on subCostType.CostType equals costType.CostTypeId
                  where costType.CostTypeId == selectedCostTypeId  
                  select projectCost );
