    public class FooBuilding : IBuilding
    {
        private IDepartmentInfoCollectionFactory factory;
        private readonly ObservableCollection<IDepartmentInfo> departmentInfos;
        public string Name { get; } = "FooBuilding";
        public ObservableCollection<IDepartmentInfo> DepartmentInfos
        {
            get { return this.departmentInfos; }
        }
        public FooBuilding(IDepartmentInfoCollectionFactory factory)
        {
            this.factory = factory;
            this.departmentInfos = factory.GetDepartments<FooBuilding>();
        }
    }
