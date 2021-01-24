    public class PropertyMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            object selectedItem = values[0];
            string displayMemberPath = values[1] as string;
    
            if (selectedItem != null)
            {
                ParameterExpression param =
                    System.Linq.Expressions.Expression.Parameter(selectedItem.GetType(), "x");
                MemberExpression body =
                    System.Linq.Expressions.Expression.Property(param, displayMemberPath);
                    
                LambdaExpression lambda =
                    System.Linq.Expressions.Expression.Lambda(body, param);
    
                Delegate expression = lambda.Compile();
                return expression.DynamicInvoke(selectedItem);
            }
            else
            {
                return null;
            }
        }
    
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
