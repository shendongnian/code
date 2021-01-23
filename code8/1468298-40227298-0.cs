    public void UpdateManagerList() {
        var member = GetUserMember();
        var managerList = db.UserList.Where(u => u.Name == "Managers" && u.OrgId == member.OrgId).FirstOrDefault();
        var listId = managerList.O_UserListId;
        // list and user ids for up to date managers.
        List<O_Member> ManagersCur = db.O_MemberWhere(u => u.OrgId == member.OrgId && u.Manage == true && u.JoinedStored == true).ToList();
        List<string> curUserIds = ManagersCur.Select(u => u.UserId).ToList();
        //list of managers stored in userlist
        List<UserListItem> ManagersList = db.UserListItem.Where(u => u.UserListId == listId).ToList();
        List<string> listUserIds = ManagersList.Select(u => u.UserId).ToList();
        foreach (var curMgrId in curUserIds) {
            if (!listUserIds.Contains(curMgrId)) {
                var newUserLI = new UserListItem();
                newUserLI.UserListId = listId;
                newUserLI.UserId = curMgrId;
                db.UserListItem.Add(newUserLI);
                db.SaveChanges();
            }
        }
