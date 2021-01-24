    public static class FamilyExtensions
    {
        public static List<Family> GroupToFamilies(this List<Person> personList)
        {
            var retval = from p in personList
                         group p by new p.address into f
                         select new Family() { personList = f.ToList() }; //If familyAddress was of type Address, you could add: familyAddress = f.Key
            return retval.ToList();
        }
    }
