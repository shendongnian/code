    ForAllPropertyMaps(pm => !pm.SourceMember.Name.EndsWith("Updated"), (pm, ce) =>
                {
                    var sourceType = pm.TypeMap.SourceType;
                    var conditionPropertyName = $"{pm.SourceMember.Name}Specified";
                    var property = sourceType.GetProperty(conditionPropertyName, BindingFlags.Instance | BindingFlags.Public);
                    if (property == null) return;
    
                    
                    var conditionParameter = Expression.Parameter(typeof(object));
                    var parameterConvertion = Expression.Convert(conditionParameter, sourceType);
                    var getPropertyValue = Expression.Property(parameterConvertion, conditionPropertyName);
                    var lambda = Expression.Lambda<Func<object, bool>>(getPropertyValue, conditionParameter);
                    ce.Condition(lambda.Compile());
                });
