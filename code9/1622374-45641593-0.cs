        public class PhoneNumber
    {
        public PhoneNumber(string name, int areaCode, string number)
        {
            Name = name;
            AreaCode = areaCode;
            Number = number;
        }
        public int ID { get; set; }
        public string Name { get; set; }
        public int AreaCode { get; set; }
        public string Number { get; set; }
    }
    }
