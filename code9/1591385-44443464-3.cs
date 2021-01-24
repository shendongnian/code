    public class SomeService : ISomeService {
        private readonly ISomeContext _context;
    
        public SomeService(ISomeContext context) {
            _context = context;
        }
    
        public async Task CreateAsync(SomeObject someObject) {
            someObject.SomeProperty = GenerateRandomString();    
            _context.SomeObjects.Add(project);    
            await _context.SaveChangesAsync();
        }
        string GenerateRandomString() {
            //...other code
        }
    }
