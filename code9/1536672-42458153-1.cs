         public class Data
        {
            public string Name { get; set; }
            public decimal Value { get; set; }
            public string ValueString { get; set; }
            public Data()
            {
            }
            public Data(string name, decimal value)
            {
                Name = name;
                Value = value;
            }
        }
