    public int[] GetUserIDArrayByPermission(int permission)
    {
      Dictionary<int, int[]> dicUserPermission=userPermssions.Where(i => i.Value.Contains(permission));
     int[] userIDArray=dicUserPermission.Select(p => p.Key).ToArray();
     return userIDArray;
    } 
