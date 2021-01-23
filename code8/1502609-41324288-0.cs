    public static async Task<List<Property>> GetProperties(int userId, int userTypeId)
    {
      entities = new MyEntities();
      var userType = await entities.sl_USER_TYPE.Where(_userType => _userType.ID == userTypeId).FirstAsync();
      var properties = await entities.sl_PROPERTY.Where(_property => _property.USER_ID == userId && _property.USER_TYPE_ID == userTypeId).ToListAsync();
      if (!properties.Any())
        throw new Exception("Error: No Properties exist for this user!");
      return ConvertEntiesToBusinessObj(properties, userId);
    }
