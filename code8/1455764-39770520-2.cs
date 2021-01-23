        class MyClass
        {
            public string MyProperty { get; set; }
            public override string ToString()
            {
                return MyProperty;
            }
        }
        string longest = comboBox1.Items.Cast<MyClass>().OrderByDescending(a => a.ToString()).FirstOrDefault().ToString();
