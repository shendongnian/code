    public bool Update(User item, HttpPostedFileBase avatar)
    {
        var tran = ContextEntities.Database.BeginTransaction(IsolationLevel.ReadUncommitted);
        try
        {
            var user = new UserDa().Get(ContextEntities, item.Id);//get current user
            CheckConstraint(item, Enums.Status.Update);
    		
    		if(user == null)
    		{
    			//throw and error or do something else
    		}}
    		
            //avatar checker
            if (avatar != null)
            {
                if (avatar.ContentType != "image/jpeg")
                    throw new Exception("[Only Jpg Is Allowed");
    
                if (user.AvatarId == null)
                {
                    user.AvatarId = new FileDa().Insert(ContextEntities, avatar);
                }
                else if (user.AvatarId != null)
                {
                    user.AvatarId = new FileDa().Update(ContextEntities, (Guid)user.AvatarId, avatar);
                }
            }
            //password checker
            user.Password = string.IsNullOrWhiteSpace(item.Password) ? user.Password : Utility.Hash.Md5(user.Password);
            //ContextEntities.Entry(item).State = EntityState.Modified;
            if (!new UserDa().Update(ContextEntities, user))
                throw new Exception();
            tran.Commit();
            return true;
        }
        catch (Exception ex)
        {
            tran.Rollback();
            throw new Exception(ex.Message);
        }
    }
