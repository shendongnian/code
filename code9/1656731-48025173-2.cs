    public static class QueryableExtensions
    {
        public static IQueryable SelectProperties<T>(this IQueryable<T> source, UserRoles roles, string criteria)
        {
            // get all the properties that a user is authorized to see
            var authenticatedProperties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public)
                .Where(prop => prop.CustomAttributes.Any(attr =>
                    attr.AttributeType == typeof(RestrictUserRoles) &&
                    (((RestrictUserRoles) Attribute.GetCustomAttribute(prop, typeof(RestrictUserRoles))).Roles & roles) !=
                    0))
                .Select(prop => prop.Name)
                .ToList();
            // if there aren't any, then the user is not
            // authorized to view any properties
            // DISCLAIMER: or someone has forgotten to mark any properties
            // with the RestrictUserRoles-attribute
            if (!authenticatedProperties.Any()) throw new UnauthorizedAccessException();
            // we get all the properties that the user wants to 
            // select from the string that was passed to the function in 
            // the form Prop1, Prop2, Prop3
            var selectProperties = criteria
                .Split(',')
                .Select(property => property.Trim());
            // Get the intersection between these properties, IE we
            // select only those properties that the user has selected
            // AND is authorized to view
            var properties = authenticatedProperties
                .Intersect(selectProperties)
                .ToList();
            // if there are none that intersect, return all those
            // properties that a user is authorized to view
            if (!properties.Any()) properties = authenticatedProperties;
            // run the query using dynamic linq
            return source.Select("new(" + properties.JoinToString(",") + ")");
        }
    }
