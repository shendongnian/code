    using System.Linq.Expressions;
    using System.Reflection;
    ...
    public static partial class FuncExtensions {
      public static Func<T, T> AbsDiff<T>(this Func<T, T> source) {
        if (null == source)
          throw new ArgumentNullException("source");
        var x = Expression.Parameter(typeof(T), "x");
        Expression<Func<T, T>> f = v => source(v);
        MethodInfo abs = typeof(Math).GetMethod("Abs", new Type[] { typeof(T) });
        var one = Expression.Convert(Expression.Constant(1), typeof(T));
        var body = Expression.Call(abs, Expression.Subtract(
          Expression.Invoke(f, x),
          Expression.Invoke(f, Expression.Subtract(x, one))));
        return Expression.Lambda(body, x).Compile() as Func<T, T>;
     }
