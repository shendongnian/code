    public static void changeVisibility(this object obj, Visibility vis) {
        var property = obj.GetType().GetProperty("visibility", BindingFlags.Instance);
        if ( property != null ) {
            property.SetValue(obj, vis);
        }
    }
