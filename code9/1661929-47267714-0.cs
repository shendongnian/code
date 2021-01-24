    [NotMapped]
    public static Expression<Func<User,int>> TotalConversionsLambda = (user => user.Statistics.Sum(sum => sum.Conversions));
    [NotMapped]
    public int TotalConversions
    {
        get
        {
            return TotalConversionsLambda.Compile().Invoke(this);
        }
    }
