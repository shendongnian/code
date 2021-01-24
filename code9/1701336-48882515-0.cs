    public class FakePerson : PersonModel {
        public new string Get() {
            return string.Empty; //Not calling the base Get
        }
    }
	
