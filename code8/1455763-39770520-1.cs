        class MyClass
        {
            public string MyProperty { get; set; }
        }
            comboBox1.Items.Add(new MyClass { MyProperty = "aaa ddd ddd" });
            comboBox1.Items.Add(new MyClass { MyProperty = "aaa" });
            comboBox1.Items.Add(new MyClass { MyProperty = "aaa ff" });
            comboBox1.Items.Add(new MyClass { MyProperty = "aaa x" });
            foreach (MyClass possibleDate in comboBox1.Items)
            {
                int stringLength = possibleDate.MyProperty.Length;
                if (stringLength > longestName.Length)
                    longestName = possibleDate.MyProperty;
            }
            Console.WriteLine(longestName);
            //or
            string longest = comboBox1.Items.Cast<MyClass>().OrderByDescending(a => a.MyProperty.Length).FirstOrDefault().MyProperty;
