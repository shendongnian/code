    class A
    {
        private BoolWrapper form_1_Enabled = new BoolWrapper(true);
        private new Dictionary<string, BoolWrapper> dict;
        public A()
        {
            dict = new Dictionary<string, BoolWrapper>() { { "is_form_1_enabled", form_1_Enabled }, };
            foreach (var i in dict)
            {
                if (i.Value.Value == true)
                {
                    i.Value.Value = false;
                }
            }
        }
        public class BoolWrapper
        {
            public bool Value { get; set; }
            public BoolWrapper(bool value) { this.Value = value; }
        }
    }
