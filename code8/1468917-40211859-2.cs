    public List<UserDto> DisplayAll()
    {
        List<UserDto> result = ctx.User  //my DbContext
                      .Select(x => new UserDto()
                      {
                      FullName = x.First_Name + " " +Last_Name,
                      Age = x.Age
                      }
        return result;
    }
