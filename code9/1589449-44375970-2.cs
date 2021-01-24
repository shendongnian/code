    public int[] GetUserIDArrayByContentPermissions()
    {            
      var dicUserPermission = userPermssions.Where(i => i.Value.Count(p=>contentPermissions.Contains(p))>0).ToList();
      int[] userIDArray = dicUserPermission.Select(p => p.Key).ToArray();
      return userIDArray;
    } 
