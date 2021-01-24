    internal class AutoMapperConfiguration
    {
        public static void Configure()
        {
            AutoMapper.Mapper.Initialize(x => x.AddProfile<EmployeeProfile>());
        }
    }
