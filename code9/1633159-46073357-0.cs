    public static IQueryable<TValue> IsInDateTimeRange<TValue>(
        this IQueryable<TValue> self,
        Expression<Func<TValue, DateTime>> getMember,
        DateTime minTime,
        DateTime maxTime)
    {
        var valueParam = getMember.Parameters.First();
        var getMemberBody = getMember.Body;
        var filter = Expression.Lambda<Func<TValue, bool>>(
            Expression.And(
                Expression.LessThanOrEqual(
                    Expression.Constant(minTime),
                    getMemberBody
                ),
                Expression.LessThanOrEqual(
                    getMemberBody,
                    Expression.Constant(maxTime)
                )
            ),
            valueParam
        );
        return self.Where(filter);
    }
