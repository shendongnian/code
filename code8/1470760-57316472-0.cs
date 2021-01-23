    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Source, Dest>().ReverseMap();
        }
    }
In Startup.cs, add below to add to DI (the assembly arg is for the class that holds your mapping configs, in my case, it's the MappingProfile class).
//add automapper DI
services.AddAutoMapper(typeof(MappingProfile));
In Controller, use it like you would any other DI object
    [Route("api/[controller]")]
    [ApiController]
    public class AnyController : ControllerBase
    {
        private readonly IMapper _mapper;
        public AnyController(IMapper mapper)
        {
            _mapper = mapper;
        }
        
        public IActionResult Get(int id)
        {
            var entity = repository.Get(id);
            var dto = _mapper.Map<Dest>(entity);
            
            return Ok(dto);
        }
    }
