    using Microsoft.AspNetCore.Html;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using System.Reflection;
    
    namespace iSee.IHtmlHelpers
    {
    
        public static class HtmlExtensions
        {
    
            public static IHtmlContent DisplayNameForLatin<TModel, TValue>(
            this IHtmlHelper<TModel> htmlHelper, Expression<Func<TModel, TValue>> expression)
            {
    
                var memberExpression = expression.Body as MemberExpression;
                if (memberExpression == null)
                {
                    return new HtmlString("");
                }
    
                var displayAttribute = memberExpression.Member.GetCustomAttribute<DisplayAttribute>();
    
                return new HtmlString(displayAttribute.Name);
    
            }
    
    
        }
    }
