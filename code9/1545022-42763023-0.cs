    public abstract class Core
    {
        public Core()
        {
            Type myType = this.GetType();
            object[] attrs = myType.GetCustomAttributes(typeof(IdAttribute), false);
            IdAttribute attr = attrs?.OfType<IdAttribute>().FirstOrDefault();
            int id = -1;
            if (attr != null) id = attr.Id;
            if (!reservedIdentities.ContainsKey(id))
            {
                reservedIdentities.Add(id, myType);
            }
            else
            {
                if (!reservedIdentities[id].Equals(myType))
                    throw new ArgumentException("Duplicate identities discovered.", nameof(id));
            }
        }
    
        static Dictionary<int, Type> reservedIdentities = new Dictionary<int, Type>();
    
        //...
    }
