    public class Person() {
        public string firstName {get; set;}
        public string lastName {get; set;}
        public string birthday {get; set;}
    
        public Person(fName, lName, bDay) {
            firstName = fName;
            lastName = lName;
            birthday = bDay;
        }
        // Addition by @MongZhu
        public override ToString() {
            return firstName + " " + lastName + " Birthday: " + birthday
        }
    }
