    public class ClientToDtosMappingProfile : Profile
    {
        public ClientToDtosMappingProfile()
        {
            CreateMap<EmployeeClient, EmployeeDto>();
            CreateMap<DepartmentClient, DepartmentDto>();
            CreateMap<OrganizationClient, OrganizationDto>()
                .AfterMap(AfterMap);
        }
        private void AfterMap(OrganizationClient client, OrganizationDto dto, ResolutionContext resolutionContext)
        {
            if (client.Employees == null)
            {
                return;
            }
            foreach (var employee in client.Employees)
            {
                var departmentDto = dto.Departments.First(d => d.Id == employee.DepartmentId);
                if (departmentDto.Employees == null)
                {
                    departmentDto.Employees = new List<EmployeeDto>();
                }
                var employeeDto = resolutionContext.Mapper.Map<EmployeeDto>(employee);
                departmentDto.Employees.Add(employeeDto);
            }
        }
    }
