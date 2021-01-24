    class Program
    {
        static void Main(string[] args)
        {
            Product p = new Product();
            var attValue = Helper.ToStringProperty(p, prod => prod.active);
            Console.WriteLine(attValue);
            Console.ReadLine();
        }
    }
    public class Product
    {
        private Boolean _active;
        [Display(Name = "Super Active")]
        public Boolean active
        {
            get
            {
                return _active;
            }
            set
            {
                _active = value;
            }
        }
    }
    public class Helper
    {
        public static string ToStringProperty<TSource, TProperty>(TSource source,
            Expression<Func<TSource, TProperty>> propertyLambda)
        {
            Type type = typeof(TSource);
            MemberExpression member = propertyLambda.Body as MemberExpression;
            if (member == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a method, not a property.",
                    propertyLambda.ToString()));
            PropertyInfo propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
                throw new ArgumentException(string.Format(
                    "Expression '{0}' refers to a field, not a property.",
                    propertyLambda.ToString()));
            if (type != propInfo.ReflectedType &&
                !type.IsSubclassOf(propInfo.ReflectedType))
                throw new ArgumentException(string.Format(
                    "Expresion '{0}' refers to a property that is not from type {1}.",
                    propertyLambda.ToString(),
                    type));
            var output = source.ToString();
            var attribute = propInfo.GetCustomAttributes(typeof(DisplayAttribute), false).Cast<DisplayAttribute>().FirstOrDefault();
            return attribute != null ? attribute.Name : output;
        }
    }
