    public class TechnicianService
    {
        private AADataContext context;
        public TechnicianService(AADataContext context)
        {
            this.context = context;
        }
        public IEnumerable<TechnicianViewModel> GetTechnicians(string branch, string status)
        {
        }
    }
