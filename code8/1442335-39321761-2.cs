    public bool Invoke(EntityType entityType, ActionType action, Object[] arguments)
        {
            var actionType = Enum.GetName(typeof(ActionType), action);
            var type = GetType();
            var method = type.GetMethods().Single(m => m.IsGenericMethod && m.Name == actionType);
            switch (entityType)
            {
                case EntityType.IncidentInjury:
                    var genericMethod = method.MakeGenericMethod(typeof(IncidentInjury));
                    return (bool)genericMethod.Invoke(this, arguments);
                default:
                    return false;
            }
        }
