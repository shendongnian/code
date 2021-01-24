    public class User
    
    {
    ...
    public List<Department> Departments { get; set; }
    public List<Company> Companies { get; set; }
    }
    
    public class DbUser
    {
    ...
    public List<UsersDepartment> UsersDepartments { get; set; }
    public List<UsersCompany> UsersCompanies { get; set; }
    }
    
    cfg.CreateMap<UserDb, User>()
    	.ForMember(dest => dest.Departments, opt => opt.MapFrom(user => user.UsersDepartments.Select(userDepartment => userDepartment.Department)))
    	.ForMember(dest => dest.Companies, opt => opt.MapFrom(user => user.UsersCompanies.Select(userCompany => userCompany.Company)));
    
    	
    cfg.CreateMap<User,DbUser>()
    	.ForMember(dest => dest.UsersDepartments, opt => opt.MapFrom( user=>user.Departments.Select( department=> new UsersDepartment{UserId=user.Id, DepartmentId=department.Id}))))
    	.ForMember(dest => dest.UsersCompanies, opt => opt.MapFrom( user=>user.Companies.Select( company=> new UsersCompany{UserId=user.Id, CompanyId=company.Id}))));
