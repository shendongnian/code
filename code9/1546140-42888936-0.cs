:)
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http.Internal;
    using Microsoft.AspNetCore.Mvc.ModelBinding;
    
    namespace Application.ValueProviders
    {
        public class CamelCaseQueryStringValueProviderFactory : IValueProviderFactory
        {
            public Task CreateValueProviderAsync(ValueProviderFactoryContext context)
            {
                if (context == null)
                    throw new ArgumentNullException(nameof(context));
                return AddValueProviderAsync(context);
            }
    
            private async Task AddValueProviderAsync(ValueProviderFactoryContext context)
            {
                var collection = context.ActionContext.HttpContext.Request.Query
                    .ToDictionary(t => ToCamelCaseFromSnakeCase(t.Key), t => t.Value, StringComparer.OrdinalIgnoreCase);
    
                var valueProvider = new QueryStringValueProvider(
                    BindingSource.Query,
                    new QueryCollection(collection),
                    CultureInfo.InvariantCulture);
    
                context.ValueProviders.Add(valueProvider);
            }
    
            private string ToCamelCaseFromSnakeCase(string str)
            {
                return str.Split(new[] { "_" },
                    StringSplitOptions.RemoveEmptyEntries).
                    Select(s => char.ToUpperInvariant(s[0]) + s.Substring(1, s.Length - 1)).
                    Aggregate(string.Empty, (s1, s2) => s1 + s2);
            }
        }
    }
