    [DataContract]
    public class RootObject
    {
        [DataMember]
        public string status { get; set; }
        [DataMember]
        object[][] staticdata
        {
            get
            {
                if (Values == null)
                    return null;
                return Values.Select(v => new object[] { v.Date, v.IntValue }).ToArray();
            }
            set
            {
                if (value == null)
                    return;
                Values = value.Select(a => new Value 
                    { 
                        Date = a.Length < 1 ? null : (string)Convert.ChangeType(a[0], typeof(string), CultureInfo.InvariantCulture),
                        IntValue = a.Length < 2 ? 0 : (int)Convert.ChangeType(a[1], typeof(int), CultureInfo.InvariantCulture) 
                    }
                    ).ToList();
            }
        }
        [IgnoreDataMember]
        public List<Value> Values { get; set; }
    }
