        public class UserController : Controller {
            // Create a field to store the mapper object
            private readonly IMapper _mapper;
            // Assign the object in the constructor for dependency injection
            public UserController(IMapper mapper) {
                _mapper = mapper;
            }
            public async Task<IActionResult> Edit(string id) {
                
                // Instantiate source object
                // (Get it from the database or whatever your code calls for)
                var user = await _context.Users
                    .SingleOrDefaultAsync(u => u.Id == id);
                
                // Instantiate the mapped data transfer object
                // using the mapper you stored in the private field.
                // The type of the source object is the first type argument
                // and the type of the destination is the second.
                // Pass the source object you just instantiated above
                // as the argument to the _mapper.Map<>() method.
                var model = _mapper.Map<User, UserDto>(user);
                
                // .... Do whatever you want after that!
            }
        }
