    public interface ISystem
    {
      int id { get; }
      ...
    }
    public interface IEmployee
    {
      ...
      int system_id { get; }
      ...
    }
    private static List<TEmployee> FilterData<TSystem, TEmployee>(
      IQueryable<TSystem> systemData, IQueryable<TEmployee> employeeData)
      where TSystem : ISystem
      where TEmployee: IEmployee
    {
      var filterData = 
          systemData.Join(employeeData,
                          s => s.id, 
                          em => em.system_id, 
                          (systemEntity, employeeEntity) => new { employee = employeeEntity});
    }
