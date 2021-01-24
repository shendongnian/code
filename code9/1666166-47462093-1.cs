    public interface IDepartmentInfosRegistry
    {
        void RegisterDepartment(Type buildingType, Func<IDepartmentInfo> departmentCreator);
        ObservableCollection<IDepartmentInfo> GetDepartments<T>() where T : class, IBuilding;
    }
