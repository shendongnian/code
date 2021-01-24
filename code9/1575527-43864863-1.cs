            // instead of passing pairs of PropertyName - PropertyValue
            // we'll pass pairs of PropertyPath - PropertyValue
            var filters = new Dictiontionary<string, object>();
            IEnumerable<CustomerProduct > query = listOfCustomerProducts;
            // we will loop through the filters
            foreach (var filter in filters)
            {
                // split property path by dot character
                var propertyNames = filter.Key.Split('.');
                PropertyInfo property = null;
                var parameter = Expression.Parameter(typeof(CustomerProduct));
                MemberExpression memberExpression = null;
                // loop through all property names in path
                foreach (var t in propertyNames)
                {
                    // get correct property type
                    var type = property == null ? typeof(CustomerProduct) : property.PropertyType;
                    // find property in the given type
                    property = type.GetProperty(t, BindingFlags.Instance | BindingFlags.Public);
                    if (property == null) break;
                    // create member expression.
                    memberExpression = memberExpression == null
                        // if there isn't one, create new, using parameter expression
                        ? Expression.Property(parameter, property)
                        // if there already is one, use it to get into the nested property
                        : Expression.Property(memberExpression, property);
                }
                
                if (property == null) continue;
                // Convert object type to the actual type of the property
                var value = Convert.ChangeType(filter.Value, property.PropertyType, CultureInfo.InvariantCulture);
                // Construct equal expression that compares MemberExpression for the property with converted value
                var eq = Expression.Equal(memberExpression, Expression.Constant(value));
                // Build lambda expresssion (x => x.SampleProperty == some-value)
                var lambdaExpression = Expression.Lambda<Func<CustomerProduct, bool>>(eq, parameter);
                // And finally use the expression to filter the collection
                query = query.Where(lambdaExpression.Compile());
            }
