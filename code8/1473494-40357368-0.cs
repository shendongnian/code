    using System.Reflection;
    ... 
    public static void Backup(InstanceClass ic) {
      if (null == ic)
        throw new ArgumentNullException("ic");
      ic.GetType()
        .GetField("oldValue", BindingFlags.NonPublic | BindingFlags.Instance)
        .SetValue(ic, ic.Value);
    }
    public static void Restore(InstanceClass ic) {
      if (null == ic)
        throw new ArgumentNullException("ic");
      ic.Value = (int) (ic.GetType()
        .GetField("oldValue", BindingFlags.NonPublic | BindingFlags.Instance)
        .GetValue(ic));
