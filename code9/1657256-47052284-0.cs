    public bool IsMemberGenerated(string name)
    {
        var field = this.GetType().GetField(name, System.Reflection.BindingFlags.Public |
            System.Reflection.BindingFlags.NonPublic |
            System.Reflection.BindingFlags.Instance);
        return field != null;
    }
