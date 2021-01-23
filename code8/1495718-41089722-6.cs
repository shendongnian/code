    public class FakeService : IExcelService {
        public IEnumerable<CustomerViewModel> GetSpreadsheet() { 
            return new List<CustomerViewModel>() { new CustomerViewModel() };
        }
    }
