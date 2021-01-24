    public class person
        {
            public string name { get; set; }
            public int age { get; set; }
        }
        public class PersonList : List<person>
        {
            public int getAge(string name)
            {
                return this.FirstOrDefault(x => x.name == name)?.age ?? -1;
            }
            public int[] getAge2(string name)
            {
                return this.Where(x => x.name == name).Select(x=>x.age).ToArray();
            }
        }
