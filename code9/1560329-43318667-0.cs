Table 1 - Users
        Users
         {
           string Name,
           int Id,
           int RoleId
         }
Table 2- Roles
        Roles
         {
           string Name,
           int Id,
           bool HasWriteAccess
         }
Table 3 - MenuItems
        MenuItems
         {
           string Title,
           int Id,
           int RoleId
         }
