    public class CommandSchedule {
        private readonly IStudenScheduleService _context;
        public CommandSchedule(IStudenScheduleService context) {
            this._context = context;
        }
        public async Task Add(StudentSchedule model) {
            await _context.AddAsync(model);
            await _context.SaveChangesAsync();
        }
    }
