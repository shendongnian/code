    public class ParsingTable<T>
    {
       /*** All the other stuff ***/
       public static IColumnConfiguration MapTo(this IColumnConfiguration config, Expression<Func<T, object>> property)
       {
          if (property.Body is MemberExpression)
          {
             config.Property = (property.Body as MemberExpression).Member as PropertyInfo;
          }
          else
          {
             config.Property = (((UnaryExpression)property.Body).Operand as MemberExpression).Member as PropertyInfo;
          }
       }
    }
    public interface IColumnConfiguration
    {
         PropertyInfo Property { get; set; }
    }
