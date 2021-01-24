    var queryLoginAdimin =
       from admin in conDb.SystemAdminMasters
       join system in conDb.SystemMasters on admin.SystemID equals system.SystemId into SM
       join category in conDb.MenuCategoryMasters on admin.SystemID equals category.SystemId into CM
       join menu in conDb.MenuMasters on admin.SystemID equals menu.SystemId into MM
       select new OnLoginData
       {
           lstTableDetails = conDb.TableMasters
                                  .Where(table => table.SystemId == admin.SystemID)
                                  .Select(o => new TableDetails
                                   {
                                       TableId = o.TableId,
                                       TableName = o.TableName,
                                       TableNumber = o.TableNumber
                                   }),
           //Same for lstCategoryDetails
        };
