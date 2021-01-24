    public T GetMember<T>(string name) where T : class
    {
        var field = this.GetType().GetField(name,
          System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        if (field == null)
            return null;
        return (T)field.GetValue(this);
    }
