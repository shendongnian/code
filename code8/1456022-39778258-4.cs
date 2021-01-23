    public class RateService : IRatesService {
        private readonly IDbContext db;
        public RateService(IDbContext dbContext) {
            this.db = dbContext;
        }
        //...
        public RatesDTO GetById(int Id) {
            return Mapper.Map<Rates, RatesDTO>(this.db.Rates.GetAll().Where(m => m.RateId == Id).First());
        }
        //...
    }
