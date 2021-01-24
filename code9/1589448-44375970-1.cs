    public int[] GetUserIDArrayByPermission(int permission)
    {
      var dicUserPermission=userPermssions.Where(i => i.Value.Contains(permission));
     int[] userIDArray=dicUserPermission.Select(p => p.Key).ToArray();
     return userIDArray;
    } 
