    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class BuildingAttribute : Attribute
    {
        public Type BuildingType { get; private set; }
        public BuildingAttribute(Type buildingType)
        {
            this.BuildingType = buildingType;
        }
    }
