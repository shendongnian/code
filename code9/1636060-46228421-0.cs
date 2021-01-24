    public class DtoToClientMappingProfile: Profile
    {
        public DtoToClientMappingProfile()
        {
            CreateMap<EmployeeDto, EmployeeClient>();
            CreateMap<DepartmentDto, DepartmentClient>();
            CreateMap<OrganizationDto, OrganizationClient>()
                .ForMember(dest => dest.Employees, opt => opt.Ignore())
                .AfterMap(AfterMap);
        }
        private void AfterMap(OrganizationDto dto, OrganizationClient client, ResolutionContext resolutionContext)
        {
            if (dto.Departments == null)
            {
                return;
            }
            client.Departments = new List<DepartmentClient>();
            foreach (var department in dto.Departments)
            {
                var departmentClient = resolutionContext.Mapper.Map<DepartmentClient>(department);
                client.Departments.Add(departmentClient);
                if (department.Employees == null)
                {
                    continue;
                }
                if (client.Employees == null)
                {
                    client.Employees = new List<EmployeeClient>();
                }
                foreach (var employee in department.Employees)
                {
                    var employeeClient = resolutionContext.Mapper.Map<EmployeeClient>(employee);
                    employeeClient.DepartmentId = department.Id;
                    client.Employees.Add(employeeClient);
                }
            }
        }
