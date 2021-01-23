    public bool Invoke(UploadInformation information, ActionType action)
    {
        var actionType = Enum.GetName(typeof(ActionType), action);
        var type = this.GetType();
        var method = type.GetMethods().Single(m => m.IsGenericMethod && m.Name == actionType);
        switch (information.Type)
        {
            case EntityType.Incident:
                var genericMethod = method.MakeGenericMethod(typeof(IncidentInjury));
                return (bool)genericMethod.Invoke(this, new[] { information });
            default:
                return false;
        }
    }
