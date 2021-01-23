    private async Task<JsonResult> Delete<T>(int? id, DbSet<T> dbs) where T : class
    {
        var parameter = Expression.Parameter(typeof(T), "entity");
        // generate expression entity => entity.ID = id
        var condition = (Expression<Func<T, bool>>) Expression.Lambda(
                Expression.Equal(
                    Expression.Property(parameter, "ID"),
                    Expression.Constant(id)
                )
            , parameter);
            
        var row = await dbs.SingleOrDefaultAsync(condition);
        dbs.Remove(row);
        await db.SaveChangesAsync();
        return Json(r);
    }
