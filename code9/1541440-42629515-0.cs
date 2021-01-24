    public abstract class IComponent
    {
        protected IList<object> objComponents;
        public object GetComponentOfType(Type type)
        {
            if (objComponents == null)
                return null;
            return objComponents.Where(obj => obj.GetType() == type).FirstOrDefault();
        }
    }
