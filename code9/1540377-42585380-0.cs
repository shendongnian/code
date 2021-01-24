    string input = "{\"Property\":\"foo\"}";
    object instanceOfA = new A();
    object result = instanceOfA.GetType().GetMethod("Process").Invoke(instanceOfA, new object[]{ input });
    public class A
    {
        public C Process(string input)
        {
            var b = (B) JsonConvert.DeserializeObject(input, typeof(B));
            if (!string.IsNullOrEmpty(b.Property))
            {
                return new C()
                {
                    Output = b.Property + " bar!"
                };
            }
            return null;
        }
    }
    public class B
    {
        public string Property { get; set; }
    }
    public class C
    {
        public string Output { get; set; }
    }
