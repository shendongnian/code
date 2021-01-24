        private List<PropertyInfo> GetNavigationProperties<T>(GesFormaContext _gesFormaContext)
        {
            List<PropertyInfo> propertyInfos = new List<PropertyInfo>();
            _gesFormaContext.Model.GetEntityTypes().Select(x => x.GetNavigations()).ToList().ForEach(entityTypes =>
            {
                entityTypes.ToList().ForEach(property =>
                {
                    propertyInfos.AddRange(typeof(T).GetProperties().Where(x => x.PropertyType == property.PropertyInfo.PropertyType).ToList());
                });
            });
           
            return propertyInfos;
        }
