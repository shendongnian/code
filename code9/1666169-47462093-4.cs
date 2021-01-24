    public class FooBuilding : IBuilding
    {
        private IDepartmentInfosRegistry registry;
        private readonly ObservableCollection<IDepartmentInfo> departmentInfos;
        public string Name { get; } = "FooBuilding";
        public ObservableCollection<IDepartmentInfo> DepartmentInfos
        {
            get { return this.departmentInfos; }
        }
        public FooBuilding(IDepartmentInfosRegistry registry)
        {
            this.registry = registry;
            this.departmentInfos = registry.GetDepartments<FooBuilding>();
        }
    }
