    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Windows.Forms;
    
    namespace DataBindingExtensions
    {
        public static class DataBindingHelper
        {
            public static void DataBind<T, K>(this TextBox textBox, T dataSource,
                Expression<Func<T, K>> property)
            {
                var memberExpression = (MemberExpression)property.Body;
                string propertyName = memberExpression.Member.Name;
                DataBind(textBox, dataSource, propertyName);
            }
            public static void DataBind<T>(this TextBox textbox, 
                T dataSource, string property)
            {
                textbox.DataBindings.Add("Text", dataSource, property, true,
                    DataSourceUpdateMode.OnValidation);
    
                var maxLengthAttribute = typeof(T).GetProperty(property)
                    .GetCustomAttributes(true)
                    .OfType<MaxLengthAttribute>().FirstOrDefault();
                if (maxLengthAttribute != null)
                    textbox.MaxLength = maxLengthAttribute.Length;
            }
        }
    }
