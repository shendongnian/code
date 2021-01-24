    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Net.Http;
    using System.Web.Http;
    using WebApiTest.Models;
    public class ProductsController : ApiController
    {
        [HttpGet]
        public IEnumerable<Product> Search([FromUri] Product product)
        {
            var parameters = Request.GetQueryNameValuePairs().Select(x => x.Key.ToLower());
            using (var db = new TestDBEntities())
            {
                var result = db.Products.AsQueryable();
                foreach (var property in typeof(Product).GetProperties())
                {
                    if (parameters.Contains(property.Name.ToLower()))
                    {
                        var x = Expression.Parameter(typeof(Product), "x");
                        var propertyExpression = Expression.Property(x, property.Name);
                        var valueExpression = Expression.Convert(
                            Expression.Constant(property.GetValue(product)), 
                                property.PropertyType);
                        var criteria = Expression.Equal(propertyExpression, valueExpression);
                        var lambda = Expression.Lambda<Func<Product, bool>>(criteria, x);
                        result = result.Where(lambda);
                    }
                }
                return result.ToList();
            }
        }
    }
