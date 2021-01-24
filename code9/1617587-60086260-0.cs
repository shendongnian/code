public static Func<T, T> SelectorFunc<T>(string[] columns) {
// input parameter "o"
var xParameter = Expression.Parameter(typeof(T), "o");
// new statement "new Data()"
var xNew = Expression.New(typeof(T));
// create initializers
var bindings = columns.Select(o => o.Trim())
 .Select(o =>
    {
        // property "Field1"
        var mi = typeof(T).GetProperty(o);
        // original value "o.Field1"
        var xOriginal = Expression.Property(xParameter, mi);
        // set value "Field1 = o.Field1"
	return Expression.Bind(mi, xOriginal);
        }
        );
	// initialization "new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        var xInit = Expression.MemberInit(xNew, bindings);
        // expression "o => new Data { Field1 = o.Field1, Field2 = o.Field2 }"
        var lambda = Expression.Lambda<Func<T, T>>(xInit, xParameter);
       // compile to Func<Data, Data>
     return lambda.Compile();
}
using it would be 
T.Select( SelectorFunc<T>( new string[]{ "Column" } ) ).Distinct().ToList();
You can also use it any other linq functions like
T.Select( SelectorFunc<T>( new string[]{ "Column" } ) ).Where();
T.Select( SelectorFunc<T>( new string[]{ "Column" } ) ).AsQueryable();
for additional reference you can see the full OP here
https://stackoverflow.com/questions/16516971/linq-dynamic-select/45205267#45205267
