    public class GenericControllerFeatureProvider : IApplicationFeatureProvider<ControllerFeature>
    {
        public void PopulateFeature(IEnumerable<ApplicationPart> parts, ControllerFeature feature)
        {
            // This is designed to run after the default ControllerTypeProvider, 
            // so the list of 'real' controllers has already been populated.
            foreach (var entityType in EntityTypes.Types)
            {
                var typeName = entityType.Name + "Controller";
                if (!feature.Controllers.Any(t => t.Name == typeName))
                {
                    // There's no 'real' controller for this entity, so add the generic version.
                    var controllerType = typeof(GenericController<>)
                        .MakeGenericType(entityType.AsType()).GetTypeInfo();
                    feature.Controllers.Add(controllerType);
                }
            }
        }
    }
