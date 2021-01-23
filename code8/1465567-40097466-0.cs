        public PersonModel Load(int personID, bool loadSpouse = true)
        {
            ...
            if (loadSpouse && person.SpouseID != null && person.Spouse == null)
            {
                person.Spouse = this.Load(person.SpouseID.Value, false);
            }
            ...
    
            return person;
        }
