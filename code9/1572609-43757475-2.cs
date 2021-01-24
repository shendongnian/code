    private const int MAX_EXPANSION_DEPTH = 10;
    private DbContext Context { get; set; } //set during construction of my repository
    
     public virtual IQueryable<TEntity> AllExcluding(string excludeProperties = "")
        {
          var propertiesToExclude = excludeProperties.Split(new[]
                                                            {
                                                              ','
                                                            },
                                                            StringSplitOptions.RemoveEmptyEntries);
    
    
          IQueryable<TEntity> initialQuery = Context.Set<TEntity>();
          var elementType = initialQuery.ElementType;
    
          var navigationPropertyPaths = new HashSet<string>();
          var navigationPropertyNames = GetNavigationPropertyNames(elementType);
          foreach (var propertyName in navigationPropertyNames)
          {
            if (!propertiesToExclude.Contains(propertyName))
            {
              ExtendNavigationPropertyPaths(navigationPropertyPaths, elementType, propertyName, propertyName, propertiesToExclude, 0);
            }
          }
    
          return navigationPropertyPaths.Aggregate(initialQuery, (current, includeProperty) => current.Include(includeProperty));
        }
    
        private void ExtendNavigationPropertyPaths(ISet<string> navigationPropertyPaths,
                                                   Type parentType,
                                                   string propertyName,
                                                   string propertyPath,
                                                   ICollection<string> propertiesToExclude,
                                                   int expansionDepth)
        {
          if (expansionDepth > MAX_EXPANSION_DEPTH)
          {
            return;
          }
    
          var propertyInfo = parentType.GetProperty(propertyName);
    
          var propertyType = propertyInfo.PropertyType;
    
          var isEnumerable = typeof(IEnumerable).IsAssignableFrom(propertyType);
          if (isEnumerable)
          {
            propertyType = propertyType.GenericTypeArguments[0];
          }
    
          var subNavigationPropertyNames = GetNavigationPropertyNames(propertyType);
          var noSubNavigationPropertiesExist = !subNavigationPropertyNames.Any();
          if (noSubNavigationPropertiesExist)
          {
            navigationPropertyPaths.Add(propertyPath);
            return;
          }
    
          foreach (var subPropertyName in subNavigationPropertyNames)
          {
            if (propertiesToExclude.Contains(subPropertyName))
            {
              navigationPropertyPaths.Add(propertyPath);
              continue;
            }
    
            var subPropertyPath = propertyPath + '.' + subPropertyName;
            ExtendNavigationPropertyPaths(navigationPropertyPaths,
                                          propertyType,
                                          subPropertyName,
                                          subPropertyPath,
                                          propertiesToExclude,
                                          expansionDepth + 1);
          }
        }
    
        private ICollection<string> GetNavigationPropertyNames(Type elementType)
        {
          var objectContext = ((IObjectContextAdapter)Context).ObjectContext;
          var entityContainer = objectContext.MetadataWorkspace.GetEntityContainer(objectContext.DefaultContainerName, DataSpace.CSpace);
          var entitySet = entityContainer.EntitySets.FirstOrDefault(item => item.ElementType.Name.Equals(elementType.Name));
          if (entitySet == null)
          {
            return new List<string>();
          }
          var entityType = entitySet.ElementType;
          return entityType.NavigationProperties.Select(np => np.Name)
                           .ToList();
        }
