    public class GroupedItemModel
    {
        public GroupedItemModel(string name, IEnumerable<string> values){
            Name = name;
            Values =  new List<string>(values);
        }
        public string Name { get;  }
        public List<string> Values { get;  }
              
    }
