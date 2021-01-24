    class Program
    {
        static public List<string> _closedTypes = new List<string>();
        static public void RegisterClosedType(Type t)
        {
            _closedTypes.Add(String.Format("{0}<{1}>",
                t.Name.Split('`')[0],
                String.Join(",", t.GenericTypeArguments.Select(q => q.Name))
                ));
        }
    }
