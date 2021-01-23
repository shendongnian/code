    private Dictionary<string, HashSet<person>> peopleList = new Dictionary<string, HashSet<person>>();
        public void loadPeople()
        {
            List<person> people = new List<person>();
            people.Add(new person() { firstName = "Shirley", lastName = "Kotarski", age = 45 });
            people.Add(new person() { firstName = "Bob", lastName = "Smith", age = 24 });
            people.Add(new person() { firstName = "Bill", lastName = "Jones", age = 32 });
            people.Add(new person() { firstName = "Jim", lastName = "Hostettler", age = 19 });
            people.Add(new person() { firstName = "Ralph", lastName = "Billings", age = 27 });
            people.Add(new person() { firstName = "Eddir", lastName = "Johnson", age = 58 });
            for (int i = 65; i < 91; i++)
            {//Partitions based on first letter of first name
                string charI = ((char)i).ToString();
                string key = charI;
                peopleList.Add(key, new HashSet<person>(people.Where(p => p.firstName.Substring(0, 1) == charI).ToArray()));
                
            }
        }
        public void processListOfPeople()
        {
            for (int i = 65; i < 91; i++)
            {
                string charI = ((char)i).ToString();
                string key = charI;
                List<person> people = peopleList[key].ToList();
             }
        }
        public person lookupPerson(string firstName)
        {
            person p = new so_Win.person();
            string key = firstName.Substring(0, 1);
            return peopleList[key].Where(m => m.firstName == firstName).ToArray()[0];
        }
