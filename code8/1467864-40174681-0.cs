    public bool IsDefaultValue(object o)
    {
        if (o == null)
            return true;
    
        var type = o.GetType();
        return type.IsValueType && o.Equals(Activator.CreateInstance(type));
    }
    object i = default(int);
    object j = default(float);
    object k = default(double);
    object s = default(string);
    object i2 = (int)2;
    object s2 = (string)"asas";
    var bi = IsDefaultValue(i); // true
    var bj = IsDefaultValue(j); // true
    var bk = IsDefaultValue(k); // true
    var bs = IsDefaultValue(s); // true
    var bi2 = IsDefaultValue(i2); // false
    var bs2 = IsDefaultValue(s2); // false
