    public string TemplateName
    {
        get
        {
            // EditorProperty must not be null... mind this is C#6 but its easy to downgrade it
            var genericType = EditorProperty?.GetType().GetGenericArguments().FirstOrDefault()?.Name;
			return $"EditorModelOf{genericType}"; 
        }
    }
