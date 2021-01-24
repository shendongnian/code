    using System.Linq;
    using System.Reflection;
    public void Reset()
    {
        foreach (var field in this.GetType().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
            .Where(x=>x.Name.EndsWith("Enabled", StringComparison.OrdinalIgnoreCase) && x.FieldType == typeof(bool)))
        {
            field.SetValue(this, false);
        }
    }
