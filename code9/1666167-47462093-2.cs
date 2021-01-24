    public class DepartmentInfosRegistry : IDepartmentInfosRegistry
    {
        private readonly Dictionary<Type, List<Func<IDepartmentInfo>>> departmentCreators =
            new Dictionary<Type, List<Func<IDepartmentInfo>>>();
        void IDepartmentInfoRegistry.RegisterDepartment(Type buildingType, Func<IDepartmentInfo> departmentCreator)
        {
            if (!this.departmentCreators.ContainsKey(buildingType))
                this.departmentCreators.Add(buildingType, new List<Func<IDepartmentInfo>>());
            if (!this.departmentCreators[buildingType].Contains(departmentCreator))
                this.departmentCreators[buildingType].Add(departmentCreator);
        }
        ObservableCollection<IDepartmentInfo> IDepartmentInfoRegistry.GetDepartments<T>()
        {
            Type type = typeof(T);
            if (!this.departmentCreators.ContainsKey(type))
                throw new InvalidOperationException(
                    string.Format("No departments have been registered for {0}.", type.ToString()));
            ObservableCollection<IDepartmentInfo> departmentInfos = new ObservableCollection<IDepartmentInfo>();
            foreach(Func<IDepartmentInfo> creator in this.departmentCreators[type])
            {
                departmentInfos.Add(creator());
            }
            return departmentInfos;
        }
    }
