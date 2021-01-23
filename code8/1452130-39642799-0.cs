    private async static Task<List<MyEntity>> DoGetMyEntityByDateAsync(MyContextType context, bool sync)
    {
      var query = context.MyEntity
          .AsNoTracking();
      return sync ?
          query.ToList() :
          await query.ToListAsync();
    }
    public static Task<List<MyEntity>> GetMyEntityByDateAsync(MyContextType context)
    {
      return DoGetMyEntityByDateAsync(context, sync: false);
    }
    public static List<MyEntity> GetMyEntityByDate(MyContextType context)
    {
      return DoGetMyEntityByDateAsync(context, sync: true).GetAwaiter().GetResult();
    }
