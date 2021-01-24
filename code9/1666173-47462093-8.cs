    public class DepartmentInfoCollectionFactory : IDepartmentInfoCollectionFactory
    {
        private readonly Dictionary<Type, List<Func<IDepartmentInfo>>> departmentCreators =
            new Dictionary<Type, List<Func<IDepartmentInfo>>>();
        void IDepartmentInfoCollectionFactory.RegisterDepartment<T>(Func<IDepartmentInfo> departmentCreator)
        {
            Type buildingType = typeof(T);
            if (!this.departmentCreators.ContainsKey(buildingType))
                this.departmentCreators.Add(buildingType, new List<Func<IDepartmentInfo>>());
            if (!this.departmentCreators[buildingType].Contains(departmentCreator))
                this.departmentCreators[buildingType].Add(departmentCreator);
        }
        ObservableCollection<IDepartmentInfo> IDepartmentInfoCollectionFactory.GetDepartments<T>()
        {
            Type buildingType = typeof(T);
            if (!this.departmentCreators.ContainsKey(buildingType))
                throw new InvalidOperationException(
                    string.Format("No departments have been registered for {0}.", buildingType.ToString()));
            ObservableCollection<IDepartmentInfo> departmentInfos = new ObservableCollection<IDepartmentInfo>();
            foreach(Func<IDepartmentInfo> creator in this.departmentCreators[buildingType])
            {
                departmentInfos.Add(creator());
            }
            return departmentInfos;
        }
    }
