        public class MyRootObject
        {
            public MyRootObject(RootObject root)
            {
                Name = root.name;
                List<CallingCode> callingCodesConverted = new List<CallingCode>();
                foreach (string code in root.callingCodes)
                {
                    CallingCode newCode = new CallingCode() { Code = code };
                    callingCodesConverted.Add(newCode);
                }
                CallingCodes = callingCodesConverted;
            }
            public string Name { get; set; }
            public List<CallingCode> CallingCodes { get; set; }
        }
