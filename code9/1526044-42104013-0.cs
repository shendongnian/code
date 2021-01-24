    public class Data 
    {
        public List<List<string>> UserInfo {get;set;}
        public List<Person> ToPersonList()
        {
            return UserInfo.Select(info=> new Person 
            {
                FirstName = info[0],
                LastName = info[1],
                Phone = info[2],
                Age = Convert.ToInt32(info[3])
            });
        }
    }
