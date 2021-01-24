	List<GroupDetails> groupUsers = app.Protection.Groups.Cast<RRGlobalGroup>()
		  .Select(group => new GroupDetails {
			  Name = group.Name,
			  Description = group.Description,
			  GroupsUsers = group.AssignedUsers.Cast<RRGlobalAssignedUser>()
				   .Select(user => user.UserId).ToList(),
			  Permissions = Listofpermissions.Select(count => group.AccessRights[count]).ToList()
		  }).ToList();
