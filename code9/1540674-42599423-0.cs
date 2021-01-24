    public static object GetValueOrDefault(this object s, object entity)
    {
        if (s == null)
            return string.Empty;
        else
            return s.GetValue(entity);
        }
    }
