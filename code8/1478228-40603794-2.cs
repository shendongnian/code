    //using static System.Linq.Expressions.Expression;
    //x
    var parameter = Parameter(typeof(FactSale));
    //x.DateKey
    var dateKey = MakeMemberAccess(parameter, typeof(FactSales).GetProperty("DateKey"));
    //(the value in startDate, as if it had been written in)
    var startDateConst = Constant(startDate);
    //x.DateKey >= (value of startDate)
    var comparison = GreaterThanOrEqual(dateKey, startDateConst);
    //x => x.DateKey >= (value of startDate)
    var lmbd = Lambda<Func<FactSale,bool>>(comparison, new [] {prm});
    //pass the expression into the Queryable.Where method
    qry = qry.Where(lmbd);
