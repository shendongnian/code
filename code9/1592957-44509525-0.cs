        public async Task<IEnumerable<PortalUser>> GetUsers(string accountCode)
        {
            var res = from u in _db.Users
                      join ur in _db.UserRoles on u.ContactGuid equals ur.ContactGuid
                      join r in _db.Roles on ur.RoleId equals r.Id
                      where ur.AccountCode == accountCode
                      select (new PortalUser(u.Id, u.FriendlyName, u.UserName, r.RoleName));
            return await res.ToListAsync();
        }
