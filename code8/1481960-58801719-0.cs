    var invalidParameters = (from m in actionContext.ModelState
                             where m.Value.Errors.Count > 0
                             select new InvalidParameter
                             {
                                  ParameterName = m.Key,
                                  ConstraintViolations = (from msg in m.Value.Errors select msg.ErrorMessage).ToArray()
                             }).AsEnumerable().ToArray();
    if (actionContext.ActionDescriptor.Parameters.Count == 1)
    {
        var nameMapper = new Dictionary<string, string>();
        foreach (var property in actionContext.ActionDescriptor.Parameters[0].ParameterType.GetProperties())
        {
            object[] attributes = property.GetCustomAttributes(typeof(JsonPropertyNameAttribute), false);
            if (attributes.Length != 1) continue;
            nameMapper.Add(property.Name, ((JsonPropertyNameAttribute) attributes[0]).Name);
        }
        var modifiedInvalidParameters = new List<InvalidParameter>();
        foreach (var invalidParameter in invalidParameters)
        {
            if(invalidParameter.ParameterName != null && nameMapper.TryGetValue(invalidParameter.ParameterName, out var mappedName))
            {
                var modifiedConstraintViolations = new List<string>();
                foreach (var constraintViolation in invalidParameter.ConstraintViolations ?? Enumerable.Empty<string>())
                {
                    modifiedConstraintViolations.Add(constraintViolation.Replace(invalidParameter.ParameterName, mappedName));
                }
                modifiedInvalidParameters.Add(new InvalidParameter
                {
                    ParameterName = mappedName,
                    ConstraintViolations = modifiedConstraintViolations.ToArray()
                });
            }
            else
            {
                modifiedInvalidParameters.Add(invalidParameter);
            }
        }
        invalidParameters = modifiedInvalidParameters.ToArray();
    }
