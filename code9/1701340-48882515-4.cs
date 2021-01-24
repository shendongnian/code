	public interface IPersonModelService {
		string Get(PersonModel person);
	}
	public class PersonModelService : IPersonModelService {
		public string Get(PersonModel person) {
			//actual implementation return some value from the db
		}
	}
