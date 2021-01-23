        class MyClass
        {
            public decimal MyProperty { get; set; }
        }
             BindingList<MyClass> source = new BindingList<MyClass>
            {
                new MyClass { MyProperty = 1.0001m},
                new MyClass { MyProperty = 100001.5555m},
                new MyClass { MyProperty = 4m},
                new MyClass { MyProperty = 300.5m }
            };
            comboBox1.DataSource = source;
            comboBox1.DisplayMember = "MyProperty";
            foreach (object possibleDate in comboBox1.Items)
            {
                int stringLength = comboBox1.GetItemText(possibleDate).Length;
                if (stringLength > longestName.Length)
                    longestName = comboBox1.GetItemText(possibleDate);
            }
            Console.WriteLine(longestName);
            //or
            string longest = comboBox1.Items.Cast<object>().Select(a => comboBox1.GetItemText(a)).OrderByDescending(a => a.Length).FirstOrDefault();
