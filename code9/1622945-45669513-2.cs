            // Supplying parameters to constructor 
            ParticipantExtended person1 = new ParticipantExtended("John", "Smith", "Male");
            // Supplying an array to the constructor 
            string[] informationAboutPerson = { "Jane", "Jones", "Female" };
            ParticipantExtended person2 = new ParticipantExtended(informationAboutPerson);
            // Results 
            string name = person1.firstName; // name = John 
            string gender = person2.gender; // gender = female 
