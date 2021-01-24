	public Echo.Common.Business.LockingManager.LockItem GetLock(Echo.Common.Business.LockingManager.LockItem.LockType lockType, int entityId, int userId, string userName, string phoneNumber, ContactInterval contactInterval = null)
	{
		Echo.Common.Business.LockingManager.LockItem theLock = new Echo.Common.Business.LockingManager.LockItem();
		try
		{
			Echo.Common.Services.LockManagerServices lockManagerServices = new Echo.Common.Services.LockManagerServices();
			Echo.Common.Services.LockItem returnedLock = lockManagerServices.GetLock((Echo.Common.Services.LockType)lockType, entityId, userId, userName, phoneNumber);
			theLock.UserId = returnedLock.UserId;
			theLock.UserName = returnedLock.UserName;
			theLock.PhoneNumber = returnedLock.PhoneNumber;
			theLock.ExpireSecs = returnedLock.ExpireSecs;
			// check if contactInterval is null, if not, use it, otherwise use default from returnedLock
			theLock.ContactInterval = (contactInterval != null) ? contactInterval : returnedLock.ContactInterval;
			int respondsID = (int)returnedLock.ResponseId;
			theLock.ResponseId = (LockItem.LockResponse)respondsID;
		}
		catch
		{
			theLock.ResponseId = LockItem.LockResponse.ERROR;
		}
		return theLock;
	}
