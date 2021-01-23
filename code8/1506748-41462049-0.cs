    public interface IUserDataService
    {
        User GetById(int id);
    }
    public class BonusCalculator
    {
        private readonly IUserdataService _dataService;
        public BonusCalculator(IUserDataService dataService)
        {
            _dataService = dataService;
        }
        public int CalculateBonusForUser(int userId)
        {
            const int BONUS = 100;
            var deservedBonus = 0;
            var user = _dataService.GetById(userId);
  
            if (user.IsDeservedBonus)
            {
                deservedBonus += BONUS;
            }
            return deservedBonus;
        }
    }
