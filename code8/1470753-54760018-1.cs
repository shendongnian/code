public class EmployeesController {
	private readonly IMapper _mapper;
	public EmployeesController(IMapper mapper)
		=> _mapper = mapper;
	// use _mapper.Map to map
}
And if you want to use ProjectTo its now simply:
var customers = await dbContext.Customers.ProjectTo<CustomerDto>(_mapper.ConfigurationProvider).ToListAsync()
