     public class Sale
                {
                    public int A { get; set; }
        
                    public int B { get; set; }
        
                    public int C { get; set; }
                }
        
                //I used a similar condition structure but my guess is you simplified the code to show in example anyway
                public class Condition
                {
                    public string ColumnName { get; set; }
        
                    public ConditionType Type { get; set; }
        
                    public object[] Values { get; set; }
        
                    public enum ConditionType
                    {
                        Range
                    }
                    
                    //This method creates the expression for the query
                    public static Expression<Func<T, bool>> CreateExpression<T>(IEnumerable<Condition> query)
                    {
                        var groups = query.GroupBy(c => c.ColumnName);
        
                        Expression exp = null;
                        //This is the parametar that will be used in you lambda function
                        var param = Expression.Parameter(typeof(T));
        
                        foreach (var group in groups)
                        {
                            // I start from a null expression so you don't use the silly 1 = 1 if this is a requirement for some reason you can make the 1 = 1 expression instead of null
                            Expression groupExp = null;
        
                            foreach (var condition in group)
                            {
                                Expression con;
                                //Just a simple type selector and remember switch is evil so you can do it another way
                                switch (condition.Type)
                                {
    //this creates the between NOTE if data types are not the same this can throw exceptions
                                    case ConditionType.Range:
                                        con = Expression.AndAlso(
                                            Expression.GreaterThanOrEqual(Expression.Property(param, condition.ColumnName), Expression.Constant(condition.Values[0])),
                                            Expression.LessThanOrEqual(Expression.Property(param, condition.ColumnName), Expression.Constant(condition.Values[1])));
                                        break;
                                    default:
                                        con = Expression.Constant(true);
                                        break;
                                }
                                // Builds an or if you need one so you dont use the 1 = 1
                                groupExp = groupExp == null ? con : Expression.OrElse(groupExp, con);
                            }
        
                            exp = exp == null ? groupExp : Expression.AndAlso(groupExp, exp);
                        }
        
                        return Expression.Lambda<Func<T, bool>>(exp,param);
                    }
                }
        
                static void Main(string[] args)
                {
                    //Simple test data as an IQueriable same as EF or any ORM that supports linq.
                    var sales = new[] 
                    {
                        new Sale{ A = 1,  B = 2 , C = 1 },
                        new Sale{ A = 4,  B = 2 , C = 1 },
                        new Sale{ A = 8,  B = 4 , C = 1 },
                        new Sale{ A = 16, B = 4 , C = 1 },
                        new Sale{ A = 32, B = 2 , C = 1 },
                        new Sale{ A = 64, B = 2 , C = 1 },
                    }.AsQueryable();
        
                    var conditions = new[]
                    {
                        new Condition { ColumnName = "A", Type = Condition.ConditionType.Range, Values= new object[]{ 0, 2 } },
                        new Condition { ColumnName = "A", Type = Condition.ConditionType.Range, Values= new object[]{ 5, 60 } },
                        new Condition { ColumnName = "B", Type = Condition.ConditionType.Range, Values= new object[]{ 1, 3 } },
                        new Condition { ColumnName = "C", Type = Condition.ConditionType.Range, Values= new object[]{ 0, 3 } },
                    };
        
                    var exp = Condition.CreateExpression<Sale>(conditions);
                    //Under no circumstances compile the expression if you do you start using the IEnumerable and they are not converted to SQL but done in memory
                    var items = sales.Where(exp).ToArray();
        
                    foreach (var sale in items)
                    {
                        Console.WriteLine($"new Sale{{ A = {sale.A},  B =  {sale.B} , C =  {sale.C} }}");
                    }
        
                    Console.ReadLine();
                }
